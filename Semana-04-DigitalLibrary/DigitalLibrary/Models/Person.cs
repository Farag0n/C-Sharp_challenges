namespace DigitalLibrary.Models;

public abstract class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string DocNumber { get; set; }
    public string Email { get; set; }
    public int CelNumber { get; set; }
    
    //Constructor vacio
    //Si no existe el constructor vacío, EF no puede instanciar la clase y saldra un error
    public Person(){}

    public Person(int id, string name, int age, string docNumber, string email, int celNumber)
    {
        ID = id;
        Name = name;
        Age = age;
        DocNumber = docNumber;
        Email = email;
        CelNumber = celNumber;
    }
}