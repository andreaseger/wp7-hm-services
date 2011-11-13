using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace hm_services.Data
{
  [Table]
  public class Entry
  {
    [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity",
            CanBeNull = false, AutoSync = AutoSync.OnInsert)]
    public int ID { get; set; }

    [Column(DbType = "NVARCHAR(2048)")]
    public string Text { get; set; }

    [Column(DbType = "NVARCHAR(256)")]
    public string Subject { get; set; }

    [Association(ThisKey = "ID", OtherKey = "EntryID")]
    public EntitySet<EntryAuthor> Authors { get; set; }

    public Entry()
    {
      Authors = new EntitySet<EntryAuthor>();
    }
  }
}
