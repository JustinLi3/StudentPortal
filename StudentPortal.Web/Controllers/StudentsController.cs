using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Models;

namespace StudentPortal.Web.Controllers
{
  public class StudentsController : Controller //You must tie the name of the controller to the view in the folder 
  {
    [HttpGet] //action would only retrieve info from a server
    public IActionResult Add() //This is how you set up the action with the keyword Add
    {
      return View(); 
    }
    [HttpPost] //action would only allow data to be sent to the server 
    public IActionResult Add(AddStudentViewModel viewModel) //When the form is submitted, it is binded in a form of data to the properties of AddStudentViewmodel
    {
      return View(); //Although data is saved in controller, we do not have a form that is getting submitted
      //we want to return the name, email, phone, and subscribed to save in the database
      //We have to create a view model in order to pass data from a controller to a view 
    }
  }
}
