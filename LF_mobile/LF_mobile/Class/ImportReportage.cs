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
    class ImportReportage
    {
        static HttpClient client = new HttpClient();

        public async Task GetReportage()
        {
            List<Reportage> reportage = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiReportages");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    reportage = JsonConvert.DeserializeObject<List<Reportage>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearReportage();
                    App.Database.SaveReportage(reportage);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки Reportage" + App.linkServer + "/Api/ApiReportages");
            }

        }
    }
}
