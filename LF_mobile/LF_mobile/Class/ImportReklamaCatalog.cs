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
    class ImportReklamaCatalog
    {
        static HttpClient client = new HttpClient();

        public async Task GetReklamaCatalog()
        {
            List<ReklamaCatalog> reklamaCatalog = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiReklamaCatalogs");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    reklamaCatalog = JsonConvert.DeserializeObject<List<ReklamaCatalog>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearReklamaCatalog();
                    App.Database.SaveReklamaCatalog(reklamaCatalog);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки ApiReklamaCatalogs" + App.linkServer + "/Api/ApiReklamaCatalogs");
            }

        }
    }
}
