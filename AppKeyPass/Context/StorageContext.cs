using AppKeyPass.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;

namespace AppKeyPass.Context
{
    class StorageContext
    {
        static string url = "https://localhost:7194/swagger/storage/";
        public static async Task<List<Storage>> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + "get"))
                {
                    request.Headers.Add("token", MainWindow.Token);
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string sResponse = await response.Content.ReadAsStringAsync();
                        List<Storage> storages = JsonConvert.DeserializeObject<List<Storage>>(sResponse);
                        return storages;
                    }
                }
            }
            return null;
        }
        public static async Task<Storage> Add(Storage newStorage)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "add"))
                {
                    request.Headers.Add("token", MainWindow.Token);
                    string jsonStorage = JsonConvert.SerializeObject(newStorage);
                    var content = new StringContent(jsonStorage, Encoding.UTF8, "application/json");
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string sResponse = await response.Content.ReadAsStringAsync();
                        Storage storage = JsonConvert.DeserializeObject<Storage>(sResponse);
                        return storage;
                    }
                }
            }
            return null;
        }
        public static async Task<Storage> Update(Storage storage)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url + "update"))
                {
                    request.Headers.Add("token", MainWindow.Token);
                    string jsonStorage = JsonConvert.SerializeObject(storage);
                    var content = new StringContent(jsonStorage, Encoding.UTF8, "application/json");
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string sResponse = await response.Content.ReadAsStringAsync();
                        Storage updateStorage = JsonConvert.DeserializeObject<Storage>(sResponse);
                        return updateStorage;
                    }
                }
            }
            return null;
        }
        public static async Task<bool> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url + "get"))
                {
                    request.Headers.Add("token", MainWindow.Token);
                    Dictionary<string, string> rawData = new Dictionary<string, string>()
                    {
                        ["id"] = id.ToString()
                    };
                    FormUrlEncodedContent content = new FormUrlEncodedContent(rawData);
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string sResponse = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
