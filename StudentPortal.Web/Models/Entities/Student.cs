namespace StudentPortal.Web.Models.Entities
{
  public class Student
  { 
    public Guid Id { get; set; } //Guid represents a unique identifier for the student entity (primary columns)
    public string Name { get; set; }  //Want to capture only Name/Email/PhoneNum/Subscribed as Id is automatically set
    public string Email { get; set; } //Capture through crud operations
    public string PhoneNum { get; set; } 
    public bool Subscribed { get; set; } 
  }
}
