using System;
using System.Collections.Generic;
using System.Windows;
using TIAS.Core.Base;
using TIAS.Core.Models;
using TIAS.Core.Structure;
using TIAS.Models;
using TIAS.Pages;

namespace TIAS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public int CurrentLevel = 0;
        private HexMap _selectLevel {  get; set; }
        public HexMap SelectLevel
        {
            get
            {
                return _selectLevel;
            }
            set
            {
                if(value != null)
                {
                    _selectLevel = value;
                    MapChanged?.Invoke(_selectLevel);
                }
            }
        }
        public List<HexMap> Maps = new List<HexMap>();
        public event Action<HexMap> MapChanged;
        //Вот это это потом уберю в отдельный класс, для логов, но щяс пускай тут будет
        private List<string> _errorMessages = new List<string>();
        public List<string> ErrorMessages
        {
            get
            {
                return _errorMessages;
            }
            set
            {
                _errorMessages = value;
                MessageBox.Show($"Ошибка: {_errorMessages[_errorMessages.Count-1]}","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            HexMap map = new HexMap(0, 25, 25);
            map.AddUnit(new Tank(0, new HexCoord(3, 2), Core.Enum.TypeAlliance.USSR));
            map.AddUnit(new Tank(0, new HexCoord(4, 2), Core.Enum.TypeAlliance.Germany));
            Maps.Add(map);
            frame.Navigate(new MainMenu());
        }
        public Unit SelectUnit;
    }
}
