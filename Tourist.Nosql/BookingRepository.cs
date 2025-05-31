using MongoDB.Driver;
using Tourist.Nosql.Models;

namespace Tourist.Nosql
{
    public class BookingRepository
    {
        private readonly IMongoCollection<BookingModel> _collection;

        public BookingRepository(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _collection = database.GetCollection<BookingModel>("bookings");
        }

        public async Task CreateAsync(BookingModel booking)
        {
            await _collection.InsertOneAsync(booking);
        }

        public async Task<List<BookingModel>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(Guid id, BookingModel updated)
        {
            await _collection.ReplaceOneAsync(b => b.Id == id, updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(b => b.Id == id);
        }
    }
}
