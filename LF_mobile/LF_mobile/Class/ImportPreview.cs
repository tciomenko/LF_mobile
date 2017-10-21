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
    class ImportPreview
    {
        static HttpClient client = new HttpClient();

        public async Task GetPreview()
        {
            List<Preview> preview = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiPreviews");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    preview = JsonConvert.DeserializeObject<List<Preview>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearPreview();
                    App.Database.SavePreview(preview);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки Preview" + App.linkServer + "/Api/ApiPreviews");
            }

        }
    }
}
