using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace hm_services.Data
{
  [Table]
  public class Author
  {
    [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity",
            CanBeNull = false, AutoSync = AutoSync.OnInsert)]
    public int ID { get; set; }

    [Column(DbType = "NVARCHAR(128) NOT NULL")]
    public string url_code { get; set; }

    [Column(DbType = "NVARCHAR(128) NOT NULL")]
    public string Name { get; set; }

    [Association(ThisKey = "ID", OtherKey = "AuthorID")]
    public EntitySet<EntryAuthor> Entries { get; set; }

    public Author()
    {
      Entries = new EntitySet<EntryAuthor>();
    }
  }
}
