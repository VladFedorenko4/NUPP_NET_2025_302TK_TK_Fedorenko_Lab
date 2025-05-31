namespace Tourist.Common.Models
{
    public class Tourist : Individual
    {
        public string FavoriteGenre { get; set; }

        public Tourist(string name, int age, string favoritegenre)
            : base(name, age)
        {
            FavoriteGenre = favoritegenre;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Улюблений жанр: {FavoriteGenre}");
        }
    }
}
