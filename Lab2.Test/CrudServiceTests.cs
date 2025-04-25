using Lab2.Models;
using Lab2.Services;
using Xunit;
using System.Threading.Tasks;

namespace Lab2App.Tests
{
    public class CrudServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddElement()
        {
            var service = new InMemoryCrudService<Train>("test_Train.json");
            var train = Train.CreateNew();

            var result = await service.CreateAsync(train);

            Assert.True(result);

            var found = await service.ReadAsync(train.Id);
            Assert.NotNull(found);
            Assert.Equal(train.Id, found.Id);
        }

        [Fact]
        public async Task RemoveAsync_ShouldRemoveElement()
        {
            var service = new InMemoryCrudService<Train>("test_Train.json");
            var train = Train.CreateNew();

            await service.CreateAsync(train);
            var result = await service.RemoveAsync(train);

            Assert.True(result);

            var found = await service.ReadAsync(train.Id);
            Assert.Null(found);
        }

        [Fact]
        public async Task ReadAllAsync_ShouldReturnElements()
        {
            var service = new InMemoryCrudService<Train>("test_Train.json");

            await service.CreateAsync(Train.CreateNew());
            await service.CreateAsync(Train.CreateNew());

            var all = await service.ReadAllAsync();

            Assert.NotEmpty(all);
        }
    }
}