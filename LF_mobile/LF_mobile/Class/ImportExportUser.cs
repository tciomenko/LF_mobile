using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LF_mobile.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LF_mobile.Class
{
    class ImportExportUser
    {
        HttpClient client = new HttpClient();

        public async Task SaveAsync(User item)
        {
            client.MaxResponseContentBufferSize = 256000;
            var uri = new Uri(App.linkServer + "/Api/ApiUsers");
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);
        }

        public  User GetUser(string uid)
        {
            User usr = null;
            try
            {
                HttpResponseMessage response =  client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiUsers").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    List<User> usrs = JsonConvert.DeserializeObject<List<User>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    usr = usrs.FirstOrDefault(x=>x.uid== uid);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки user" + App.linkServer + "/Api/ApiShopCatalogs");
            }
            return usr;
        }
    }
}
