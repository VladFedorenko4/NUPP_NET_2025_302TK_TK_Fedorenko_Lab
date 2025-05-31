using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tourist.Common.Services;
using Tourist.Infrastructure;
using Tourist.Infrastructure.Models;
using Tourist.Infrastructure.Repository;
using Tourist.Nosql;

namespace Tourist.Console
{
    internal class Program
    {
        public delegate void TicketAddedHandler(BookingModel ticket);
        public static event TicketAddedHandler OnTicketAdded;

        static async Task Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<TouristContext>(options =>
                        options.UseNpgsql("Host=localhost; Database=Tourist; Username=postgres; Password=postgres"));

                    services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                    services.AddTransient(typeof(ICrudService<>), typeof(CrudService<>));
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var tourPackageService = services.GetRequiredService<ICrudService<TourPackageModel>>();

            await tourPackageService.CreateAsync(new TourPackageModel("Турція", "Стамбул", 2025, 7.6));
            await tourPackageService.CreateAsync(new TourPackageModel("Франція", "Париж", 2025, 8.2));
            await tourPackageService.CreateAsync(new TourPackageModel("Італія", "Рим", 2025, 7));
            await tourPackageService.CreateAsync(new TourPackageModel("Іспанія", "Мадрид", 2025, 8));
            await tourPackageService.CreateAsync(new TourPackageModel("Таїланд", "Бангкок", 2025, 6));
            await tourPackageService.CreateAsync(new TourPackageModel("Велика Британія", "Лондон", 2025, 8));

            await tourPackageService.SaveAsync();
            System.Console.WriteLine($"Дані збережено у базу даних");

            System.Console.WriteLine("Список фільмів\n");

            foreach (var i in await tourPackageService.ReadAllAsync())
            {
                System.Console.WriteLine($"{i.Id}, {i.Title}, {i.Genre}, {i.Year}, {i.Rating}");
            }

            OnTicketAdded += t =>
            {
                System.Console.WriteLine($"\nДодано новий квиток: {t.Id}, {t.MovieTitle}, {t.ShowTime}, {t.Price}");
            };

            var bookingService = services.GetRequiredService<ICrudService<BookingModel>>();
            await AddTicketAsync(bookingService, new BookingModel("Турція", DateTime.Now.AddHours(2), 120));
            await AddTicketAsync(bookingService, new BookingModel("Франція", DateTime.Now.AddHours(3), 100));
            await AddTicketAsync(bookingService, new BookingModel("Італія", DateTime.Now.AddHours(4), 170));
            await AddTicketAsync(bookingService, new BookingModel("Іспанія", DateTime.Now.AddHours(4), 190));
            await AddTicketAsync(bookingService, new BookingModel("Таїланд", DateTime.Now.AddHours(4), 90));
            await AddTicketAsync(bookingService, new BookingModel("Велика Британія", DateTime.Now.AddHours(4), 134));

            System.Console.WriteLine("\nСписок квитків:\n");
            var bookings = await bookingService.ReadAllAsync();

            foreach (var t in bookings)
            {
                System.Console.WriteLine($"{t.Id}, {t.MovieTitle}, {t.ShowTime}, {t.Price}");
            }

            System.Console.WriteLine($"\nЗагальна сума продажів: {bookings.CalculateTotalPrice()} EUR");

            var noSqlService = new NoSqlService();
            await noSqlService.DemostrateAsync();

            System.Console.ReadLine();
        }

        private static async Task AddTicketAsync(ICrudService<BookingModel> bookingService, BookingModel newTicket)
        {
            await bookingService.CreateAsync(newTicket);
            OnTicketAdded?.Invoke(newTicket);
        }
    }
}