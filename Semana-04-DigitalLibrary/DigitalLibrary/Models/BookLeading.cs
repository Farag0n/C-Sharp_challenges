namespace DigitalLibrary.Models;

public class BookLeading
{
    public int ID { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateOnly ReturnDate { get; set; }
    public bool ReturnState { get; set; }
    
    //Relacines
    public Book Book { get; set; }
    public User User { get; set; }
    
    //Constructor vacio
    //Si no existe el constructor vacío, EF no puede instanciar la clase y saldra un error
    public BookLeading(){}

    public BookLeading(int id, int userId, int bookId, DateOnly returnDate, bool returnState)
    {
        ID = id;
        UserId = userId;
        BookId = bookId;
        ReturnDate = returnDate;
        ReturnState = returnState;
    }
}