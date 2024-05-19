using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
      //Setting up database connection by using 'options'
    {
    } 
    public DbSet<Student> Students {  get; set; } //Referencing a student collection/table by which we can get and set
  }
}
//Now that weve created DbContext, we want to inject this into our application using dependency injection