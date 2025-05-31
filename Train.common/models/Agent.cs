namespace Tourist.Common.Models
{
    public class Agent : Individual
    {
        public string Position { get; set; }

        public Agent(string name, int age, string position)
              : base(name, age)
        {
            Position = position;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Посадаа: {Position}");
        }
    }
}
