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
    class ImportGood
    {
        static HttpClient client = new HttpClient();

        public async Task GetGood()
        {
            List<Good> good = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiShopCatalgGoods");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    good = JsonConvert.DeserializeObject<List<Good>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearGood();
                    App.Database.SaveGood(good);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки Good" + App.linkServer + "/Api/ApiShopCatalgGoods");
            }

        }
    }
}
