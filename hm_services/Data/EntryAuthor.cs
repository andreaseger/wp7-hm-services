using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace hm_services.Data
{
  [Table]
  public class EntryAuthor
  {
    [Column(IsPrimaryKey = true)]
    public int EntryID { get; set; }

    [Column(IsPrimaryKey = true)]
    public int AuthorID { get; set; }

    private EntityRef<Author> author;
    [Association(ThisKey = "AuthorID", OtherKey = "ID", Storage = "author")]
    public Author Author { get { return author.Entity; } set { author.Entity = value; } }

    private EntityRef<Entry> entry;
    [Association(ThisKey = "EntryID", OtherKey = "ID", Storage = "entry")]
    public Entry Entry { get { return entry.Entity; } set { entry.Entity = value; } }
  }
}
