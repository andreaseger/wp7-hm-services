using System.Data.Linq;

namespace hm_services.Data
{
  public class HMContext : DataContext
  {
    public HMContext() : base("isostore:/hm_services.sdf") { }

    public Table<Entry> News;
    public Table<EntryAuthor> EntryAuthors;
    public Table<Author> Authors;
  }
}
