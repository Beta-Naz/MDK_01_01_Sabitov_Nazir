using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TIAS.Core.Enum;
using TIAS.Core.Factory;
using TIAS.Core.Models;
using TIAS.Core.Structure;

namespace TIAS.Core.Database
{
    public class MapDatabase
    {
        private string connectionString;
        private UnitFactory _unitFactory;

        public MapDatabase(string server, string database, string userId, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={userId};Pwd={password};";
            _unitFactory = new UnitFactory();
        }

        public List<HexMap> LoadAllMaps()
        {
            var maps = new List<HexMap>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Загружаем все карты
                string mapQuery = "SELECT * FROM Maps WHERE is_active = TRUE";
                using (var command = new MySqlCommand(mapQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var map = new HexMap
                        (
                            reader.GetInt32("id"),
                            reader.GetInt32("width"),
                            reader.GetInt32("height")
                        );

                        maps.Add(map);
                    }
                }

                // Для каждой карты загружаем клетки и юнитов
                foreach (var map in maps)
                {
                    LoadMapCells(connection, map);
                    LoadMapUnits(connection, map);
                }
            }

            return maps;
        }

        private void LoadMapCells(MySqlConnection connection, HexMap map)
        {
            string query = @"
                SELECT mc.pos_q, mc.pos_r, ct.type_name 
                FROM MapCells mc
                JOIN CellTypes ct ON mc.cell_type_id = ct.id
                WHERE mc.map_id = @mapId";

            map.Cells = new CellType[map.Width, map.Height];

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@mapId", map.Id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int q = reader.GetInt32("pos_q");
                        int r = reader.GetInt32("pos_r");
                        string typeName = reader.GetString("type_name");

                        if (q < map.Width && r < map.Height)
                        {
                            map.Cells[q, r] = (CellType)System.Enum.Parse(typeof(CellType), typeName);
                        }
                    }
                }
            }
        }

        private void LoadMapUnits(MySqlConnection connection, HexMap map)
        {
            string query = @"
                SELECT mu.pos_q, mu.pos_r, u.unit_type, u.alliance, u.id
                FROM MapUnits mu
                JOIN Units u ON mu.unit_id = u.id
                WHERE mu.map_id = @mapId";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@mapId", map.Id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int q = reader.GetInt32("pos_q");
                        int r = reader.GetInt32("pos_r");
                        string unitTypeStr = reader.GetString("unit_type");
                        string allianceStr = reader.GetString("alliance");
                        int id = reader.GetInt32("id");

                        UnitType unitType = (UnitType)System.Enum.Parse(typeof(UnitType), unitTypeStr);
                        TypeAlliance alliance = (TypeAlliance)System.Enum.Parse(typeof(TypeAlliance), allianceStr);
                        var unit = _unitFactory.CreateUnit(id, new HexCoord(q, r), unitType, alliance);
                        map.AddUnit(unit);
                    }
                }
            }
        }

        public void SaveMap(HexMap map)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    // Сохраняем карту
                    string insertMap = "INSERT INTO Maps (map_name, width, height) VALUES (@name, @width, @height); SELECT LAST_INSERT_ID();";
                    int mapId;

                    using (var command = new MySqlCommand(insertMap, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@name", $"Level {map.Id}");
                        command.Parameters.AddWithValue("@width", map.Width);
                        command.Parameters.AddWithValue("@height", map.Height);
                        mapId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Сохраняем клетки
                    for (int q = 0; q < map.Width; q++)
                    {
                        for (int r = 0; r < map.Height; r++)
                        {
                            string insertCell = @"
                                INSERT INTO MapCells (map_id, pos_q, pos_r, cell_type_id)
                                VALUES (@mapId, @q, @r, (SELECT id FROM CellTypes WHERE type_name = @type))";

                            using (var command = new MySqlCommand(insertCell, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@mapId", mapId);
                                command.Parameters.AddWithValue("@q", q);
                                command.Parameters.AddWithValue("@r", r);
                                command.Parameters.AddWithValue("@type", map.Cells[q, r].ToString());
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // Сохраняем юнитов
                    foreach (var unit in map.Units)
                    {
                        string insertUnit = @"
                            INSERT INTO MapUnits (map_id, unit_id, pos_q, pos_r)
                            VALUES (@mapId, (SELECT id FROM Units WHERE unit_name = @unitName), @q, @r)";

                        using (var command = new MySqlCommand(insertUnit, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@mapId", mapId);
                            command.Parameters.AddWithValue("@unitName", unit.UnitName);
                            command.Parameters.AddWithValue("@q", unit.Position.Q);
                            command.Parameters.AddWithValue("@r", unit.Position.R);
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
