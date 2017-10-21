using SQLite;

namespace LF_mobile.Model
{
    [Table("Catalogs")]
    public class Catalog
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public int id_sub_category { get; set; }
        public string name { get; set; }
        public string ltl_description { get; set; }
        public string full_description { get; set; }
        public string adress { get; set; }
        public string adress_latittude { get; set; }
        public string adress_longitude { get; set; }
        public string phone { get; set; }
        public string time_job { get; set; }
        public string site { get; set; }
        public bool wifi { get; set; }
        public bool parking { get; set; }
        public bool visa { get; set; }
        public bool delivery { get; set; }
        public string img { get; set; }
        public string img_header { get; set; }
		public string instagram { get; set; }
        public int ordering { get; set; }
    }
}
