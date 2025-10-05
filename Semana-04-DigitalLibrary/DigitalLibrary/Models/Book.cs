namespace DigitalLibrary.Models;

public class Book
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string? Writer { get; set; }
    public DateOnly Relased{ get; set; }
    public int Stock { get; set; }

    public Book(int id, string name, string? writer, DateOnly relased, int stock)
    {
        ID = id;
        Name = name;
        Writer = writer;
        Relased = relased;
        Stock = stock;
    }
}