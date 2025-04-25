using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Services;

namespace Lab2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new InMemoryCrudService<Train>("Train.json");

            var tasks = Enumerable.Range(0, 1000)
                .Select(_ => service.CreateAsync(Train.CreateNew()))
                .ToArray();

            await Task.WhenAll(tasks);

            await service.SaveAsync();

            var allTrain = await service.ReadAllAsync();

            var min = allTrain.Min(b => b.Capacity);
            var max = allTrain.Max(b => b.Capacity);
            var avg = allTrain.Average(b => b.Capacity);

            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Average: {avg:F2}");

            Console.WriteLine("Train saved to file successfully.");
        }
    }
}