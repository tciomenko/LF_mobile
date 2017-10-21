using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LF_mobile.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;

namespace LF_mobile.Class
{
    class ImportReportageImg
    {
        static HttpClient client = new HttpClient();

        public async Task GetReportageImg()
        {
            List<ReportageImg> reportageImg = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiReportageImgs");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    reportageImg = JsonConvert.DeserializeObject<List<ReportageImg>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearReportageImg();
                    App.Database.SaveReportageImg(reportageImg);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки ReportageImg" + App.linkServer + "/Api/ApiReportageImgs");
            }

        }
    }
}
