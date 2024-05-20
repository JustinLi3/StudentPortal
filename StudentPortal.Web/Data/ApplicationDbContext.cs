using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{
  public class ApplicationDbContext: DbContext //To use DbContext, we must create a class that inherits DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) //In order to allow DbContext to do any useful work, we must create an instance
      //Setting up database connection by using 'options'
    {
    }  
    //DbContext class includes a DbSet<TEntity> property for each entity in the model
    public DbSet<Student> Students {  get; set; } //Referencing a student collection/table by which we can get and set
  }
}
//Now that weve created DbContext, we want to inject this into our application using dependency injection