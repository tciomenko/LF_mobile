using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    [Table("Forum")]
    public class Forum
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public string theme_name { get; set; }
    }
}
