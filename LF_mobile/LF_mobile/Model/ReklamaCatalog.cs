using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("ReklamaCatalog")]
    public class ReklamaCatalog
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public int id_reklama_category { get; set; }
        public int id_catalog { get; set; }
        public int id_reklama_number { get; set; }
        public string img { get; set; }
    }
}
