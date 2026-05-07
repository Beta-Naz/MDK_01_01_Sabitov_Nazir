using System.Net;
using System.Net.Http;
using System.Text;
using AppKeyPass.Models;
using Newtonsoft.Json;

namespace AppKeyPass.Context
{
    public class UserContext
    {
        static string url = "https://localhost:7194/swagger/user/";
        /// <summary>
        /// Асинхронный метод аутентификации пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>JWT токен при успешном входе, null при ошибке</returns>
        public static async Task<string> Login(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "login"))
                {
                    Dictionary<string, string> formData = new Dictionary<string, string>()
                    {
                        ["login"] = login,
                        ["password"] = password
                    };
                    FormUrlEncodedContent content = new FormUrlEncodedContent(formData);
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string sResponse = await response.Content.ReadAsStringAsync();
                        Auth dataAuth = JsonConvert.DeserializeObject<Auth>(sResponse);
                        return dataAuth.Token;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Асинхронный метод регистрации пользователя
        /// </summary>
        /// <param name="user">Данные нового пользователя</param>
        /// <returns>Создался ли пользователь</returns>
        public static async Task<bool> Create(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "create"))
                {
                   string json = JsonConvert.SerializeObject(user);
                   var content = new StringContent(json, Encoding.UTF8, "application/json");
                   request.Content = content;
                   var response = await client.SendAsync(request);
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
