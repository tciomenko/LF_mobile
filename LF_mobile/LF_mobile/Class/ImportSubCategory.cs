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
    class ImportSubCategory
    {
        static HttpClient client = new HttpClient();

        public async Task GetSubCategory()
        {
            List<SubCategory> subCategories = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiShopSubCategories");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    subCategories = JsonConvert.DeserializeObject<List<SubCategory>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearSubCategories();
                    App.Database.SaveSubCategories(subCategories);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки SubCategory " + App.linkServer + "/Api/ApiShopSubCategories");
            }

        }
    }
}
