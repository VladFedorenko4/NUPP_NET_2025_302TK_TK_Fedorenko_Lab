using Tourist.Nosql.Models;

namespace Tourist.Nosql
{
    public class NoSqlService
    {
        public async Task DemostrateAsync()
        {
            var repository = new BookingRepository("mongodb://localhost:27017", "TouristDb");

            // Create
            await repository.CreateAsync(new BookingModel("Турція", DateTime.UtcNow, 120));
            System.Console.WriteLine($"Дані збережено у базу даних");

            // Read
            System.Console.WriteLine("\nСписок квитків:\n");
            var bookings = await repository.GetAllAsync();

            foreach (var t in bookings)
            {
                System.Console.WriteLine($"{t.Id}, {t.MovieTitle}, {t.ShowTime}, {t.Price}");
            }

            // Update
            var booking = bookings[0];
            booking.Price = 150;
            await repository.UpdateAsync(booking.Id, booking);

            System.Console.WriteLine("\nСписок квитків після оновлення:\n");
            bookings = await repository.GetAllAsync();

            foreach (var t in bookings)
            {
                System.Console.WriteLine($"{t.Id}, {t.MovieTitle}, {t.ShowTime}, {t.Price}");
            }

            // Delete
            await repository.DeleteAsync(booking.Id);

            System.Console.WriteLine("\nСписок квитків після видалення:\n");
            bookings = await repository.GetAllAsync();

            foreach (var t in bookings)
            {
                System.Console.WriteLine($"{t.Id}, {t.MovieTitle}, {t.ShowTime}, {t.Price}");
            }
        }
    }
}
