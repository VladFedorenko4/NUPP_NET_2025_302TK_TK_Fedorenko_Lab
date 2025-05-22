using Tourist.common;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Tourist.common.models;
using Tourist.common.services;

namespace Tourist.Console
{
    internal class Program
    {
        public delegate void TicketAddedHandler(Booking ticket);
        public static event TicketAddedHandler? OnTicketAdded;
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            var movieService = new CrudService<TourPackage>();

            movieService.Create(new TourPackage("Турція", "Стамбул", 2025, 7.6));
            movieService.Create(new TourPackage("Франція", "Париж", 2025, 8.2));
            movieService.Create(new TourPackage("Італія", "Рим", 2025, 7));
            movieService.Create(new TourPackage("Іспанія", "Мадрид", 2025, 8));
            movieService.Create(new TourPackage("Таїланд", "Бангкок", 2025, 6));
            movieService.Create(new TourPackage("Велика Британія", "Лондон", 2025, 8));

            string filePath = "movies.json";

            movieService.Save(filePath);
            System.Console.WriteLine($"\nДані збережено у файл: {filePath}");

            System.Console.WriteLine("\nПісля очищення:");
            var emptyService = new CrudService<TourPackage>();
            foreach (var m in emptyService.ReadAll())
            {
                System.Console.WriteLine(m);
            }

            emptyService.Load(filePath);
            System.Console.WriteLine("\nПісля завантаження з файлу:");
            foreach (var m in emptyService.ReadAll())
            {
                System.Console.WriteLine(m);
            }


            System.Console.WriteLine("Список фільмів\n");

            foreach (var movie in movieService.ReadAll())
            {
                System.Console.WriteLine(movie);
            }
            List<Booking> Bookings = new List<Booking>();

            OnTicketAdded += Booking =>
            {
                System.Console.WriteLine($"\nДодано новий квиток: {Booking}");
            };

            AddTicket(Bookings, new Booking("Турція", DateTime.Now.AddHours(2), 120));
            AddTicket(Bookings, new Booking("Франція", DateTime.Now.AddHours(3), 100));
            AddTicket(Bookings, new Booking("Італія", DateTime.Now.AddHours(4), 170));
            AddTicket(Bookings, new Booking("Іспанія", DateTime.Now.AddHours(4), 190));
            AddTicket(Bookings, new Booking("Таїланд", DateTime.Now.AddHours(4), 90));
            AddTicket(Bookings, new Booking("Велика Британія", DateTime.Now.AddHours(4), 134));

            System.Console.WriteLine("\nСписок квитків:\n");
            foreach (var ticket in Bookings)
            {
                System.Console.WriteLine(ticket);
            }

            System.Console.WriteLine($"\nЗагальна сума продажів: {Bookings.CalculateTotalPrice()} EUR");

            System.Console.ReadLine();
        }
        public static void AddTicket(List<Booking> tickets, Booking newTicket)
        {
            tickets.Add(newTicket);
            OnTicketAdded?.Invoke(newTicket);
        }
    }

}