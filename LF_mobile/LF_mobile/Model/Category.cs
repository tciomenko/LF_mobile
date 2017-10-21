using SQLite;

namespace LF_mobile.Model
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, Column("_id")]
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
    }
}
