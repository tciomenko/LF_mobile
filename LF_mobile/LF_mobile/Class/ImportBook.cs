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
    class ImportBook
    {
        static HttpClient client = new HttpClient();

        public async Task GetBooks()
        {
            List<Book> books = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiBooks");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearBook();
                    App.Database.SaveBook(books);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки Books" + App.linkServer + "/Api/ApiBooks");
            }

        }
    }
}
