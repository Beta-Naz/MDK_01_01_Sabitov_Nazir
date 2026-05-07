using KeyPass_Sabitov.Classes;
using KeyPass_Sabitov.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyPass_Sabitov.Controllers
{
    [Route("/user")]
    public class UserConroller : Controller
    {
        private DataBaseManager _dataBaseManager = new();

        /// <summary>
        /// Метод для аутентификации ползователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароь пользователя</param>
        /// <returns>JWT токен или код ошибки</returns>
        [Route("login")]
        [HttpPost]
        public ActionResult Login([FromForm] string login, [FromForm] string password)
        {
            try
            {
                User? AuthUser = _dataBaseManager.Users
                    .Where(x => x.Login == login && x.Password == BCrypt.Net.BCrypt.HashPassword(password))
                    .FirstOrDefault();
                if(AuthUser == null)
                {
                    return StatusCode(401);
                }
                string token = JwtToken.Generate(AuthUser);
                AuthUser.LastAuth = DateTime.Now;
                _dataBaseManager.SaveChanges();
                return Ok(new {token = token});
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        /// <summary>
        /// Мктод для создания пользователя
        /// </summary>
        /// <param name="newUser">Данные нового пользователя</param>
        /// <returns></returns>
        [Route("create")]
        [HttpPost]
        public ActionResult Create([FromBody] User newUser)
        {
            try
            {
                if(newUser == null)
                {
                    return StatusCode(401);
                }
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
                _dataBaseManager.Users.Add(newUser);
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
