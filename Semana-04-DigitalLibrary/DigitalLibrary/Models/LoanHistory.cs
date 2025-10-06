using Microsoft.AspNetCore.SignalR;

namespace DigitalLibrary.Models;

public class LoanHistory
{
    public int ID { get; set; }
    public int BookLendingId { get; set; }

    //Relaciones
    public BookLeading BookLeading { get; set; }
    
    //Constructor vacio
    //Si no existe el constructor vacío, EF no puede instanciar la clase y saldra un error
    public LoanHistory(){}
    
    public LoanHistory(int id, int bLendingId)
    {
        ID = id;
        BookLendingId = bLendingId;
    }
}