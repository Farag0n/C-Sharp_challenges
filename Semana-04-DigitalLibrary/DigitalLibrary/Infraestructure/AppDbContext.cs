namespace DigitalLibrary.Infraestructure;

using Microsoft.EntityFrameworkCore;
using DigitalLibrary.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BookLeading> BookLeadings { get; set; }
    
}
