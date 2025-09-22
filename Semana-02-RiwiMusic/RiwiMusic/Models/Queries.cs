using System;
using System.Linq;

namespace RiwiMusic.Models;

public class Queries
{
    // 1. Consultar conciertos por ciudad
        public static void ConcertsByCity(string city)
        {
            var concerts = Concerts.concertList
                .Where(c => c.description.Contains(city, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!concerts.Any())
            {
                Console.WriteLine($"No hay conciertos en la ciudad {city}");
                return;
            }

            foreach (var c in concerts)
            {
                Console.WriteLine($"{c.id} - {c.name} - {c.description} - {c.concertDate}");
            }
        }

        // 2. Consultar conciertos por rango de fechas
        public static void ConcertsByDateRange(DateOnly start, DateOnly end)
        {
            var concerts = Concerts.concertList
                .Where(c => c.concertDate >= start && c.concertDate <= end)
                .ToList();

            if (!concerts.Any())
            {
                Console.WriteLine("No hay conciertos en ese rango de fechas");
                return;
            }

            foreach (var c in concerts)
            {
                Console.WriteLine($"{c.id} - {c.name} - {c.concertDate}");
            }
        }

        // 3. Concierto con más tiquetes vendidos
        public static void TopConcertByTickets()
        {
            var query = Tickets.ticketList
                .GroupBy(t => t.ConsertId)
                .Select(g => new
                {
                    ConcertId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            if (query == null)
            {
                Console.WriteLine("No hay tiquetes vendidos aún");
                return;
            }

            var concert = Concerts.concertList.FirstOrDefault(c => c.id == query.ConcertId);
            Console.WriteLine($"Concierto con más tiquetes vendidos: {concert?.name} ({query.Count} tickets)");
        }

        // 4. Ingresos totales de un concierto
        public static void ConcertRevenue(int concertId)
        {
            var concert = Concerts.concertList.FirstOrDefault(c => c.id == concertId);

            if (concert == null)
            {
                Console.WriteLine("Concierto no encontrado");
                return;
            }

            var ticketCount = Tickets.ticketList.Count(t => t.ConsertId == concertId);
            var total = ticketCount * concert.concertPrice;

            Console.WriteLine($"Ingresos totales del concierto {concert.name}: ${total}");
        }

        // 5. Cliente con más compras realizadas
        public static void TopClient()
        {
            var query = Tickets.ticketList
                .GroupBy(t => t.ClientId)
                .Select(g => new
                {
                    ClientId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            if (query == null)
            {
                Console.WriteLine("No hay clientes con compras");
                return;
            }

            var client = Clients.clientsList.FirstOrDefault(c => c.id == query.ClientId);
            Console.WriteLine($"Cliente con más compras: {client?.name} ({query.Count} tickets)");
        }
}