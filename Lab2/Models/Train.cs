using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Interfaces;

namespace Lab2.Models
{
    public class Train : IIdentifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Model { get; set; }
        public int Capacity { get; set; }

        public static Train CreateNew()
        {
            var rnd = new Random();
            return new Train
            {
                Model = $"Model-{rnd.Next(1000, 9999)}",
                Capacity = rnd.Next(1000, 2000)
            };
        }
    }
}