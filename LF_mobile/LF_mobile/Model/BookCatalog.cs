using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("BookCatalog")]
    public class BookCatalog
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public int id_book_category { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string site { get; set; }
        public string address { get; set; }
        public string time_job { get; set; }
    }
}
