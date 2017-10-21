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
    class ImportCategory
    {
        static HttpClient client = new HttpClient();

        public async Task GetCategory()
        {
            List<Category> categories = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiShopCategories");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Category>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearCategories();
                    App.Database.SaveCategories(categories);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки Category" + App.linkServer + "/Api/ApiShopCategories");
            }

        }
    }
}
