using Microsoft.AspNetCore.SignalR;

namespace DigitalLibrary.Models;

public class LoanHistory
{
    public int ID { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public int BookLendingId { get; set; }

    public LoanHistory(int id, int userId, int bookId, int bLendingId)
    {
        ID = id;
        UserId = userId;
        BookId = bookId;
        BookLendingId = bLendingId;
    }
}