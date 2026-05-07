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
                    .Where(x => x.Login == login && x.Password == password)
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
    }
}
