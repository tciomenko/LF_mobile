using SQLite;

namespace LF_mobile.Model
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public int id_category { get; set; }
        public string name { get; set; }
        public string img { get; set; }
    }
}
