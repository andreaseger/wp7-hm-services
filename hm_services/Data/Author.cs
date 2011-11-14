using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace hm_services.Data
{
  [Table]
  public class Author
  {
    [Column(IsPrimaryKey = true, DbType = "NVARCHAR(128) NOT NULL Identity",
            CanBeNull = false, AutoSync = AutoSync.OnInsert)]
    public string Code { get; set; }

    [Column(DbType = "NVARCHAR(64) NOT NULL")]
    public string LastName { get; set; }

    [Column(DbType = "NVARCHAR(64) NOT NULL")]
    public string FirstName { get; set; }

    [Column(DbType = "NVARCHAR(64)")]
    public string Title { get; set; }

    public string full_name()
    {
      return Title + " " + FirstName + " " + LastName;
    }
  }
}
