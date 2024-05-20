using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
  public class StudentsController : Controller //You must tie the name of the controller to the view in the folder  
    //Inject DbContext class inside controller
  {
    private readonly ApplicationDbContext dbContext; //useful for 

    public StudentsController(ApplicationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    [HttpGet] //action would only retrieve info from a server
    public IActionResult Add() //This is how you set up the action with the keyword Add
    {
      return View(); 
    }



    [HttpPost] //action would only allow data to be sent to the server 
    public async Task<IActionResult> Add(AddStudentViewModel viewModel) //When the form is submitted, it is binded in a form of data to the properties of AddStudentViewmodel
    { //async to allow method to run while other programs are running, Task<IActionResult> is a return type where after the task is finished, it would return an action type
      //to use information, we first must inject DBcontext class inside the controller to save data  
      var student = new Student
      {
        Name = viewModel.Name,
        Email = viewModel.Email,
        PhoneNum = viewModel.PhoneNum,
        Subscribed = viewModel.Subscribed
      };
      await dbContext.Students.AddAsync(student); //adds a new student object to the 'Students' DbSet, schedules student to be inserted into the database 
      await dbContext.SaveChangesAsync(); //saves all changes made to the database


      return View(); //Although data is saved in controller, we do not have a form that is getting submitted
      //we want to return the name, email, phone, and subscribed to save in the database
      //We have to create a view model in order to pass data from a controller to a view 
    }

    [HttpGet]
    public async Task<IActionResult> List() //Right click and add view
    {
      var students = await dbContext.Students.ToListAsync(); //storing the list as a variable model, now we must set it as a view 
      return View(students);
    }

    [HttpGet] 
    public async Task<IActionResult> Edit(Guid id)
    {
      var student = await dbContext.Students.FindAsync(id); //Find student of id  (You might get a junk id, false id, so we must check it again in the html)
      
      return View(student);

    }

    [HttpPost] 
    public async Task<IActionResult> Edit(Student viewModel)
    {
      var student = await dbContext.Students.FindAsync(viewModel.Id);
      if (student != null)
      {
        student.Name = viewModel.Name; 
        student.Email = viewModel.Email; 
        student.PhoneNum = viewModel.PhoneNum; 
        student.Subscribed = viewModel.Subscribed;      
        
        await dbContext.SaveChangesAsync(); //does not add a new object, just overwrites old student

      } 
      return RedirectToAction("List","Students"); //After saving changes, we are redirected back to the list
    } 
  }
}
