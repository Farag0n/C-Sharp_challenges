namespace DigitalLibrary.Models;

public class User : Person
{
    public DateOnly RegistrationDate { get; set; }
    
    //Constructor vacio
    //Si no existe el constructor vacío, EF no puede instanciar la clase y saldra un error
    public User(){}
    
    public User(int id, string name, int age, string docNumber, string email, int celNumber, DateOnly registrationDate) 
        : base (id,  name, age,  docNumber, email, celNumber)
    {
        RegistrationDate = registrationDate;
    }
}