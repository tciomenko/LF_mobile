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
    class ImportForum
    {
        static HttpClient client = new HttpClient();

        public async Task GetForum()
        {
            List<Forum> forum = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiFora");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    forum = JsonConvert.DeserializeObject<List<Forum>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearForum();
                    App.Database.SaveForum(forum);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки forum" + App.linkServer + "/Api/ApiFora");
            }

        }
    }
}
