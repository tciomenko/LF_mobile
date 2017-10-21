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
    class ImportBookCategory
    {
        static HttpClient client = new HttpClient();

        public async Task GetBooksCalegory()
        {
            List<BookCategory> booksCategory = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(App.linkServer + "/handler.ashx?apiName=ApiBookCategories");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    booksCategory = JsonConvert.DeserializeObject<List<BookCategory>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
                    App.Database.ClearBookCategory();
                    App.Database.SaveBookCategory(booksCategory);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("=============Ошибка загрузки ApiBookCategories" + App.linkServer + "/Api/ApiBookCategories");
            }

        }
    }
}
