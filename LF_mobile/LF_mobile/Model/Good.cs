using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("Good")]
    public class Good
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public string name { get; set; }
        public int id_catalog { get; set; }
        public string description { get; set; }
    }
}
