namespace RiwiMusic.Models;

public class Clients
{
    public List<Clients> clientsList= new List<Clients>();
    public List<Ticket> ticketsPurchased = new List<Ticket>();
    
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string docNumber { get; set; }
    
    
    //Constructor
    public Clients(int id, string name, int age, string docNumber, List<Ticket> ticketsPurchased)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.docNumber = docNumber;
        this.ticketsPurchased = ticketsPurchased;
    }

    public static void RegisterClient()
    {
        Console.WriteLine("Ingrese el ID del cliente");
        int id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Ingrese el nombre del cliente");
        string name = Console.ReadLine();
        
        Console.WriteLine("Ingrese la edad del cliente");
        int age = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Ingrese el numero de documento del cliente");
        string docNumber = Console.ReadLine();
        
        new Clients {id = id, name = name, age = age, docNumber = docNumber};
    }
}