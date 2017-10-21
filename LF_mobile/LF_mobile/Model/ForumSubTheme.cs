using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LF_mobile.Model
{
    public class ForumSubTheme
    {
		public int id { get; set; }
        public int theme_id { get; set; }
		public int countmessages { get; set; }
		public System.DateTime date_add { get; set; }
		public string name { get; set; }
		public string message { get; set; }

	}
}
