namespace RiwiMusic.Models;

public class Admin
{
    public int id { get; set; }
    public string user { get; set; }
    public string password { get; set; }
    
    //Constructor
    public Admin(int id, string user, string password)
    {
        this.id = id;
        this.user = user;
        this.password = password;
    }
}