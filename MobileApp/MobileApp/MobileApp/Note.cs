using SQLite;

namespace MobileApp
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
