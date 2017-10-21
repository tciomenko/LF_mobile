using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("GoodPhoto")]
    public class GoodPhoto
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public int id_goods { get; set; }
    }
}
