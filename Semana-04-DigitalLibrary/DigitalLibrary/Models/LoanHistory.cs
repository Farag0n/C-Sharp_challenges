using Microsoft.AspNetCore.SignalR;

namespace DigitalLibrary.Models;

public class LoanHistory
{
    public int ID { get; set; }
    public int BookLendingId { get; set; }

    //Relaciones
    public BookLeading BookLeading { get; set; }
    public LoanHistory(int id, int bLendingId)
    {
        ID = id;
        BookLendingId = bLendingId;
    }
}