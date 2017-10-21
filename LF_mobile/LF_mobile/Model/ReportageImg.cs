using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("ReportageImg")]
    public class ReportageImg
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public int reportage_id { get; set; }
        public string img { get; set; }
    }
}
