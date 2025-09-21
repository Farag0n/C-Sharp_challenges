namespace RiwiMusic.Models;

public class Tickets
{
    public int id { get; set; }
    public int ConsertId { get; set; }
    public int ClientId { get; set; }
    
    //Constructor
    public Tickets(int id, int ConsertId, int ClientId)
    {
        this.id = id;
        this.ConsertId = ConsertId;
        this.ClientId = ClientId;
    }
}