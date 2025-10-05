namespace DigitalLibrary.Models;

public class User : Person
{
    public DateOnly RegistrationDate;
    public User(int id, string name, string docNumber, string email, int celNumber, DateOnly registrationDate) 
        : base (id,  name,  docNumber, email, celNumber)
    {
        RegistrationDate = registrationDate;
    }
}