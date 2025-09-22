using RiwiMusic.Models;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("===== Menú Principal =====");
            Console.WriteLine("1. Gestión de Conciertos");
            Console.WriteLine("2. Gestión de Clientes");
            Console.WriteLine("3. Gestión de Tiquetes");
            Console.WriteLine("4. Historial de Compras");
            Console.WriteLine("5. Consultas Avanzadas");
            Console.WriteLine("6. Salir");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": MenuConcerts(); break;
                case "2": MenuClients(); break;
                case "3": MenuTickets(); break;
                case "4": Clients.ShowPurchaseHistory(); break;
                case "5": MenuQueries(); break;
                case "6": exit = true; break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
    }

    static void MenuConcerts()
    {
        Console.WriteLine("1. Registrar concierto");
        Console.WriteLine("2. Listar conciertos");
        Console.WriteLine("3. Editar concierto");
        Console.WriteLine("4. Eliminar concierto");

        string option = Console.ReadLine();
        switch (option)
        {
            case "1": Concerts.RegisterConsert(); break;
            case "2": Concerts.ListConcerts(); break;
            case "3": Concerts.EditConcert(); break;
            case "4": Concerts.DeleteConcert(); break;
        }
    }

    static void MenuClients()
    {
        Console.WriteLine("1. Registrar cliente");
        Console.WriteLine("2. Listar clientes");
        Console.WriteLine("3. Editar cliente");
        Console.WriteLine("4. Eliminar cliente");

        string option = Console.ReadLine();
        switch (option)
        {
            case "1": Clients.RegisterClient(); break;
            case "2": Clients.ListClients(); break;
            case "3": Clients.EditClient(); break;
            case "4": Clients.DeleteClient(); break;
        }
    }

    static void MenuTickets()
    {
        Console.WriteLine("1. Registrar ticket");
        Console.WriteLine("2. Listar tickets");
        Console.WriteLine("3. Editar ticket");
        Console.WriteLine("4. Eliminar ticket");

        string option = Console.ReadLine();
        switch (option)
        {
            case "1": Tickets.RegisterTicket(); break;
            case "2": Tickets.ListTickets(); break;
            case "3": Tickets.EditTicket(); break;
            case "4": Tickets.DeleteTicket(); break;
        }
    }

    static void MenuQueries()
    {
        Console.WriteLine("1. Conciertos por rango de fechas");
        Console.WriteLine("2. Concierto con más tiquetes vendidos");
        Console.WriteLine("3. Ingresos totales de un concierto");
        Console.WriteLine("4. Cliente con más compras");
        Console.WriteLine("5. Conciertos por ciudad");

        string option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Console.WriteLine("Ingrese la fecha de inicio (YYYY-MM-DD): ");
                DateOnly start = DateOnly.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la fecha de fin (YYYY-MM-DD): ");
                DateOnly end = DateOnly.Parse(Console.ReadLine());

                Queries.ConcertsByDateRange(start, end);
                break;

            case "2":
                Queries.TopConcertByTickets();
                break;

            case "3":
                Console.WriteLine("Ingrese el ID del concierto: ");
                int concertId = int.Parse(Console.ReadLine());
                Queries.ConcertRevenue(concertId);
                break;

            case "4":
                Queries.TopClient();
                break;

            case "5":
                Console.WriteLine("Ingrese la ciudad: ");
                string city = Console.ReadLine();
                Queries.ConcertsByCity(city);
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}