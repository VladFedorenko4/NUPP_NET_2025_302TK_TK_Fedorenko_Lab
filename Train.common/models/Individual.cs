namespace Tourist.Common.Models
{
    public abstract class Individual
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }


        public static int TotalPeople = 0;

        public Individual(string name, int age)
        {
            Name = name;
            Age = age;
            TotalPeople++;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
        }

        static Individual()
        {
            Console.WriteLine("Створено клас Individual");
        }
    }
}
