namespace DigitalLibrary.Models;

public class User : Person
{
    public DateOnly RegistrationDate { get; set; }
    
    //Constructor vacio
    public User(){}
    
    public User(int id, string name, int age, string docNumber, string email, int celNumber, DateOnly registrationDate) 
        : base (id,  name, age,  docNumber, email, celNumber)
    {
        RegistrationDate = registrationDate;
    }
}