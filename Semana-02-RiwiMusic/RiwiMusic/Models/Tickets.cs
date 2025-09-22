using System;
using System.Collections.Generic;
using System.Linq;

namespace RiwiMusic.Models;

public class Tickets
{
    public int id { get; set; }
    public int ConsertId { get; set; }
    public int ClientId { get; set; }
    
    // Constructor
    // -------------------------------------------------------------------------------
    public Tickets(int id, int ConsertId, int ClientId)
    {
        this.id = id;
        this.ConsertId = ConsertId;
        this.ClientId = ClientId;
    }
    // -------------------------------------------------------------------------------

    // Lista para almacenar los tickets
    // -------------------------------------------------------------------------------
    public static List<Tickets> ticketList = new List<Tickets>();
    // -------------------------------------------------------------------------------

    // Metodo para registrar un ticket
    // -------------------------------------------------------------------------------
    public static void RegisterTicket()
    {
        Console.WriteLine("Ingrese el ID del ticket:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del concierto:");
        int concertId = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el ID del cliente:");
        int clientId = int.Parse(Console.ReadLine());
        
        var concert = Concerts.concertList.FirstOrDefault(c => c.id == concertId);
        var client = Clients.clientsList.FirstOrDefault(c => c.id == clientId);

        if (concert == null)
        {
            Console.WriteLine("Concierto no encontrado.");
            return;
        }

        if (client == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        Tickets newTicket = new Tickets(id, concertId, clientId);
        ticketList.Add(newTicket);

        // Relación: cliente compra ticket
        client.ticketsPurchased.Add(newTicket);

        Console.WriteLine("Ticket registrado exitosamente");
    }
    // -------------------------------------------------------------------------------

    // Metodo para mostrar la lista de tickets
    // -------------------------------------------------------------------------------
    public static void ListTickets()
    {
        if (ticketList.Count == 0)
        {
            Console.WriteLine("No hay tickets registrados");
            return;
        }
        else if (ticketList.Count >= 1)
        {
            Console.WriteLine("===== Lista de Tickets =====");
            foreach (var ticket in ticketList)
            {
                Console.WriteLine($"ID: {ticket.id}");
                Console.WriteLine($"ID Concierto: {ticket.ConsertId}");
                Console.WriteLine($"ID Cliente: {ticket.ClientId}");
                Console.WriteLine("-------------------------------------------------------");
            }
            return;
        }
        else
        {
            Console.WriteLine("Error inesperado al realizar la peticion");
        }
    }
    // -------------------------------------------------------------------------------

    // Metodo para editar
    // -------------------------------------------------------------------------------
    public static void EditTicket()
    {
        Console.WriteLine("Ingrese el ID del ticket que desea editar:");
        int id = int.Parse(Console.ReadLine());

        foreach (var ticket in ticketList)
        {
            if (ticket.id != id)
            {
                Console.WriteLine("El Ticket no existe");
                return;
            }
            else if (ticket.id == id)
            {
                Console.WriteLine("Operacion exitosa");
                Console.WriteLine("Ingrese el nuevo ID del concierto:");
                ticket.ConsertId = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo ID del cliente:");
                ticket.ClientId = int.Parse(Console.ReadLine());
            }
        }
    }
    // -------------------------------------------------------------------------------

    // Metodo para eliminar
    // -------------------------------------------------------------------------------
    public static void DeleteTicket()
    {
        Console.WriteLine("Ingrese el ID del ticket a eliminar:");
        int id = int.Parse(Console.ReadLine());

        // Consulta LINQ sin expresión lambda
        var query =
            from ticket in ticketList
            where ticket.id == id
            select ticket;

        Tickets ticketToRemove = query.FirstOrDefault();

        if (ticketToRemove == null)
        {
            Console.WriteLine("Ticket no encontrado.");
            return;
        }

        ticketList.Remove(ticketToRemove);
        Console.WriteLine("Ticket eliminado correctamente.");
    }
    // -------------------------------------------------------------------------------
}
