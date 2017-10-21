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
    class ImportGoodPhoto
    {
        static HttpClient client = new HttpClient();

        public async Task GetGoodPhoto()
        {
            List<GoodPhoto> goodPhoto = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiShopCatalogGoodsPhotoes");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    goodPhoto = JsonConvert.DeserializeObject<List<GoodPhoto>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearGoodPhoto();
                    App.Database.SaveGoodPhoto(goodPhoto);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки GoodPhoto" + App.linkServer + "/Api/ApiShopCatalogGoodsPhotoes");
            }

        }
    }
}
