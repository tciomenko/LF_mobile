using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("Preview")]
    public class Preview
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public string time { get; set; }
        public string money { get; set; }
        public string site { get; set; }
        public string img { get; set; }
    }
}
