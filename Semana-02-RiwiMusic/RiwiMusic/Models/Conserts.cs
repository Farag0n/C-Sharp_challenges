namespace RiwiMusic.Models;

public class Conserts
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateOnly concertDate { get; set; }
    public double concertPrice { get; set; }
    // Constructor
    public Concerts(int id, string name, string description, DateOnly concertDate, double concertPrice)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.concertDate = concertDate;
        this.concertPrice = concertPrice;
    }
}