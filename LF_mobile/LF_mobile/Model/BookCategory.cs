using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("BookCategory")]
    public class BookCategory
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public int id_book { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }
}
