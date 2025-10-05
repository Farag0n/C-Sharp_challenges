namespace DigitalLibrary.Models;

public abstract class Person
{
    protected int ID { get; set; }
    protected string Name { get; set; }
    protected string DocNumber { get; set; }
    protected string Email { get; set; }
    protected int CelNumber { get; set; }

    public Person(int id, string name, string docNumber, string email, int celNumber)
    {
        ID = id;
        Name = name;
        DocNumber = docNumber;
        Email = email;
        CelNumber = celNumber;
    }
}