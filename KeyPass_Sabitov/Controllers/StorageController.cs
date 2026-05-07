using KeyPass_Sabitov.Classes;
using KeyPass_Sabitov.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyPass_Sabitov.Controllers
{
    [Route("/storage")]
    public class StorageController : Controller
    {
        private DataBaseManager _dataBaseManager = new();
        /// <summary>
        /// Получение всех записей хранилища для авторизованного пользователя
        /// </summary>
        /// <param name="token">JWT токен из заголовка запроса</param>
        /// <returns>Список записей хранилища в формате DTO (без информации о пользователе)</returns>
        [Route("get")]
        [HttpGet]
        public ActionResult Get([FromHeader] string token)
        {
            try
            {
                int? idUser = JwtToken.GetUserIdFromToken(token);
                if (idUser == null) return StatusCode(401);
                List<StorageDto> Storages = _dataBaseManager.Storages
                    .Where(x => x.User.Id == idUser)
                    .Select(s => new StorageDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Url = s.Url,
                        Login = s.Login,
                        Password = s.Password,
                    })
                    .ToList();
                return Ok(Storages);
            }
            catch (Exception exp)
            {
                return StatusCode(501, exp.Message);
            }
        }
        /// <summary>
        /// Добавление новой записи в хранилище
        /// </summary>
        /// <param name="token">JWT токен из заголовка</param>
        /// <param name="storage">Данные новой записи (JSON в теле запроса)</param>
        /// <returns>Добавленная запись</returns>
        [Route("add")]
        [HttpPost]
        public ActionResult Add([FromForm] string token, [FromBody] Storage storage)
        {
            try
            {
                int? idUser = JwtToken.GetUserIdFromToken (token);
                if (idUser == null)
                    return StatusCode(401);
                storage.User = _dataBaseManager.Users
                    .Where(x => x.Id == idUser)
                    .First();
                _dataBaseManager.Add(storage);
                _dataBaseManager.SaveChanges();
                storage.User = null;
                return StatusCode(200, storage);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        /// <summary>
        /// Обновление существующей записи
        /// </summary>
        /// <param name="token">JWT токен из заголовка</param>
        /// <param name="storage">Обновленные данные записи</param>
        /// <returns>Обновленная запись</returns>
        [Route("update")]
        [HttpPut]
        public ActionResult Update([FromForm] string token, [FromForm]  Storage storage)
        {
            try
            {
                int? idUser = JwtToken.GetUserIdFromToken(token);
                Storage? uStorage = _dataBaseManager.Storages
                    .Where(x => x.Id == storage.Id)
                    .FirstOrDefault();
                if (idUser == null)
                    return StatusCode(401);
                if (uStorage == null)
                    return StatusCode(404);
                uStorage.Name = storage.Name;
                uStorage.Url = storage.Url;
                uStorage.Login = storage.Login;
                uStorage.Password = storage.Password;
                _dataBaseManager.SaveChanges();
                storage.User = null;
                return StatusCode(200, storage);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }
        /// <summary>
        /// Удаление записи из хранилища
        /// </summary>
        /// <param name="token">JWT токен из заголовка</param>
        /// <param name="id">ID удаляемой записи (из формы)</param>
        /// <returns>Статус выполнения операции</returns>
        [Route("delete")]
        [HttpDelete]
        public ActionResult Delete([FromForm] string token, [FromForm] int id)
        {
            try
            {
                int? idUser = JwtToken.GetUserIdFromToken(token);
                Storage? storage = _dataBaseManager.Storages
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if (idUser == null)
                    return StatusCode(401);
                if (storage == null)
                    return StatusCode(404);
                _dataBaseManager.Storages.Remove(storage);
                _dataBaseManager.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
    }
}
