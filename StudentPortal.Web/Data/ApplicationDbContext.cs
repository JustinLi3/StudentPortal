using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Web.Data
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
      //Setting up database connection by using 'options'
    {
        
    }
  }
}
