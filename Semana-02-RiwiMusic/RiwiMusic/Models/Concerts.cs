using System;
using System.Collections.Generic;

namespace RiwiMusic.Models;

public class Concerts
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateOnly concertDate { get; set; }
    public double concertPrice { get; set; }
    
    // Constructor
    // -------------------------------------------------------------------------------
    public Concerts(int id, string name, string description, DateOnly concertDate, double concertPrice)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.concertDate = concertDate;
        this.concertPrice = concertPrice;
    }
    // -------------------------------------------------------------------------------
    
    //Lista para almacenar los conciertos
    // -------------------------------------------------------------------------------
    public static List<Concerts> concertList = new List<Concerts>();
    // -------------------------------------------------------------------------------

    //Metodo para registrar un concierto
    // -------------------------------------------------------------------------------
    public static void RegisterConsert()
    {
        Console.WriteLine("Ingrese el id del concierto:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nombre del concierto:");
        string name = Console.ReadLine().ToLower();

        Console.WriteLine("Ingrese la descripción del concierto:");
        string description = Console.ReadLine().ToLower();

        Console.WriteLine("Ingrese la fecha del concierto (yyyy-MM-dd):");
        DateOnly concertDate = DateOnly.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el precio del ticket:");
        double concertPrice = double.Parse(Console.ReadLine());

        Concerts newConcert = new Concerts(id, name, description, concertDate, concertPrice);
        concertList.Add(newConcert);

        Console.WriteLine("Concierto registrado exitosamente.");
    }
    // -------------------------------------------------------------------------------
    
    //Metodo para mostrar la lista de conciertos
    // -------------------------------------------------------------------------------
    public static void ListConcerts()
    {
        if (concertList.Count == 0)
        {
            Console.WriteLine("No hay conciertos registrados");
            return;
        }
        else if (concertList.Count >= 1)
        {
            Console.WriteLine("===== Lista de Conciertos =====");
            foreach (var concert in concertList)
            {
                Console.WriteLine($"ID: {concert.id}");
                Console.WriteLine($"Nombre: {concert.name}");
                Console.WriteLine($"Descripcion: {concert.description}");
                Console.WriteLine($"Fecha: {concert.concertDate}");
                Console.WriteLine($"Precio de unitario de entrada: {concert.concertPrice}");
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
    
    //Metodo para editar
    // -------------------------------------------------------------------------------
    public static void EditConcert()
    {
        Console.WriteLine("Ingrese el id del concerto que desea editar:");
        int id = int.Parse(Console.ReadLine());

        foreach (var concert in concertList)
        {
            if (concert.id != id)
            {
                Console.WriteLine("El Concierto no existe");
                return;
            }
            else if (concert.id == id)
            {
                Console.WriteLine("Operacion exitosa");
                Console.WriteLine("Ingrese el nuevo nombre del concierto:");
                concert.name = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva descripción del concierto:");
                concert.description = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva fecha (yyyy/mm/dd):");
                concert.concertDate = DateOnly.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo precio:");
                concert.concertPrice = double.Parse(Console.ReadLine());

                Console.WriteLine("Concierto actualizado correctamente.");
            }
        }
    }
    // -------------------------------------------------------------------------------
    
    //Metodo para eliminar
    // -------------------------------------------------------------------------------
    public static void DeleteConcert()
    {
        Console.WriteLine("Ingrese el id del concierto a eliminar:");
        int id = int.Parse(Console.ReadLine());
        
        var query =
            from c in concertList
            where c.id == id
            select c;

        Concerts concert = query.FirstOrDefault();

        if (concert == null)
        {
            Console.WriteLine("Concierto no encontrado.");
            return;
        }

        concertList.Remove(concert);
        Console.WriteLine("Concierto eliminado correctamente.");
    }
    // -------------------------------------------------------------------------------
}