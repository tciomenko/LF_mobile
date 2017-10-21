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
    class ImportBookCatalog
    {
        static HttpClient client = new HttpClient();

        public async Task GetBookCatalog()
        {
            List<BookCatalog> booksCatalog = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiBookCatalogs");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    booksCatalog = JsonConvert.DeserializeObject<List<BookCatalog>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearBookCatalog();
                    App.Database.SaveBookCatalog(booksCatalog);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки BookCatalogs" + App.linkServer + "/Api/ApiBookCatalogs");
            }

        }
    }
}
