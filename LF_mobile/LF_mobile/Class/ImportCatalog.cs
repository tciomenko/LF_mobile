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
    class ImportCatalog
    {
        static HttpClient client = new HttpClient();

        public async Task GetCatalog()
        {
            List<Catalog> calaogs = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiShopCatalogs");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    calaogs = JsonConvert.DeserializeObject<List<Catalog>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearCatalogs();
                    App.Database.SaveCatalogs(calaogs);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки Catalog" + App.linkServer + "/Api/ApiShopCatalogs");
            }

        }
    }
}
