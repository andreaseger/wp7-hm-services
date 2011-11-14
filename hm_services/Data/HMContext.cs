using System.Data.Linq;

namespace hm_services.Data
{
  public class HMContext : DataContext
  {
    public HMContext() : base("isostore:/hm_services.sdf") { }

    public Table<Author> Authors;
  }
}
