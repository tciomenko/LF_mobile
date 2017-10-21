using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("Reportage")]
   public class Reportage
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public string name { get; set; }
        public string organization_name { get; set; }
        public string datte_reportaje { get; set; }
        public string img_one { get; set; }
        public string img_two { get; set; }
        public string img_three { get; set; }
        public string img_four { get; set; }
        public string img_five { get; set; }
    }
}
