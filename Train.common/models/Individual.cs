using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist.common.models
{
    public abstract class Individual
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static int TotalPeople = 0;

        static Individual()
        {
            Console.WriteLine("Створено клас Individual");
        }

        public Individual(string name, int age)
        {
            ID = Guid.NewGuid();
            Name = name;
            Age = age;
            TotalPeople++;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
        }
    }
}
