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
    class ImportNews
    {
        static HttpClient client = new HttpClient();

        public async Task GetNews()
        {
            List<News> news = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiNews");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    news = JsonConvert.DeserializeObject<List<News>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearNews();
                    App.Database.SaveNews(news);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки News" + App.linkServer + "/Api/ApiNews");
            }

        }
    }
}
