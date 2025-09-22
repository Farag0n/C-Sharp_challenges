using System;
using System.Collections.Generic;
using System.Linq;

namespace RiwiMusic.Models
{
    public class Clients
    {
        public static List<Clients> clientsList = new List<Clients>();

        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string docNumber { get; set; }

        // Constructor
        // -------------------------------------------------------------------------------
        public Clients(int id, string name, int age, string docNumber)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.docNumber = docNumber;
        }
        // -------------------------------------------------------------------------------
        
        //Lista para almacenar los Clientes
        // -------------------------------------------------------------------------------
        public static List<Clients> clientsList = new List<Clients>();
        // -------------------------------------------------------------------------------
        
        // Relación con tickets
        // -------------------------------------------------------------------------------
        public List<Ticket> ticketsPurchased { get; set; } = new List<Ticket>();
        // -------------------------------------------------------------------------------

        //Metodo para egistrar cliente
        // -----------------------------------------------------------------------
        public static void RegisterClient()
        {
            Console.WriteLine("Ingrese el ID del cliente:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del cliente:");
            string name = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del cliente:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el número de documento del cliente:");
            string docNumber = Console.ReadLine();

            Clients newClient = new Clients(id, name, age, docNumber);
            clientsList.Add(newClient);

            Console.WriteLine("Cliente registrado exitosamente.");
        }
        // -----------------------------------------------------------------------

        //Metodo para mostrar la lista de clientes
        // -----------------------------------------------------------------------
        public static void ListClients()
        {
            if (clientsList.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            Console.WriteLine("===== Lista de Clientes =====");
            foreach (var client in clientsList)
            {
                Console.WriteLine($"ID: {client.id}");
                Console.WriteLine($"Nombre: {client.name}");
                Console.WriteLine($"Edad: {client.age}");
                Console.WriteLine($"Documento: {client.docNumber}");
                Console.WriteLine("------------------------------------------");
            }
        }
        // -----------------------------------------------------------------------

        //Metodo para editar clientes
        // -----------------------------------------------------------------------
        public static void EditClient()
        {
            Console.WriteLine("Ingrese el ID del cliente que desea editar:");
            int id = int.Parse(Console.ReadLine());

            Clients client = clientsList.FirstOrDefault(c => c.id == id);

            if (client == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo nombre del cliente:");
            client.name = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva edad del cliente:");
            client.age = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo número de documento del cliente:");
            client.docNumber = Console.ReadLine();

            Console.WriteLine("Cliente actualizado correctamente.");
        }
        // -----------------------------------------------------------------------

        //Metodo para eliminar clientes
        // -----------------------------------------------------------------------
        public static void DeleteClient()
        {
            Console.WriteLine("Ingrese el ID del cliente a eliminar:");
            int id = int.Parse(Console.ReadLine());

            var query =
                from client in clientsList
                where client.id == id
                select client;

            Clients clientToRemove = query.FirstOrDefault();

            if (clientToRemove == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            clientsList.Remove(clientToRemove);
            Console.WriteLine("Cliente eliminado correctamente.");
        }
        // -----------------------------------------------------------------------
        
        //Metodo para ver las compras de un cliente
        // -----------------------------------------------------------------------
        public static void ShowPurchaseHistory()
        {
            Console.WriteLine("Ingrese el ID del cliente:");
            int id = int.Parse(Console.ReadLine());

            Clients client = clientsList.FirstOrDefault(c => c.id == id);

            if (client == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            if (client.ticketsPurchased.Count == 0)
            {
                Console.WriteLine("El cliente no ha realizado compras.");
                return;
            }

            Console.WriteLine($"Historial de compras de {client.name}:");
            foreach (var ticket in client.ticketsPurchased)
            {
                var concert = Concerts.concertList.FirstOrDefault(c => c.id == ticket.ConsertId);
                Console.WriteLine($"Ticket ID: {ticket.id} - Concierto: {concert?.name} - Fecha: {concert?.concertDate}");
            }
        }
        // -----------------------------------------------------------------------
        
    }
}
