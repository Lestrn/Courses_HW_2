namespace Courses_HW2_Part_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, int> booksPages = new Dictionary<string, int>(10);
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                booksPages.Add($"Book  #{i}", random.Next(50, 250));
            }
            foreach (var bookPage in booksPages)
            {
                Console.WriteLine($"{bookPage.Key} Pages = {bookPage.Value}");
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"Thickest book {CollectionHelper.FindTheThickestBook(booksPages)}");
            Dictionary<string, int> carsSpeeds = new Dictionary<string, int>(10);
            for (int i = 0; i < 40; i++)
            {
                carsSpeeds.Add($"Car #{i}", random.Next(40, 350));
            }
            foreach (var carSpeed in carsSpeeds)
            {
                Console.WriteLine($"{carSpeed.Key} Speed = {carSpeed.Value}");
            }
            Console.WriteLine(new string('-', 20));
            var Indexes = CollectionHelper.IndexOfFastestCar(carsSpeeds);
            Console.WriteLine($"First fastest index {Indexes.first}, last fastest index {Indexes.last}");
        }
    }
}