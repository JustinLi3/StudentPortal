namespace StudentPortal.Web.Models
{
  public class AddStudentViewModel //this view model will only contain the fields needed when adding a new student through a form in the Add file
  {
    public string Name { get; set; }  
    public string Email { get; set; }
    public string PhoneNum { get; set; }
    public bool Subscribed { get; set; }
  }
}
