namespace Courses_HW_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StringHelper stringHelper = new StringHelper(""); // Was trying to find every possible way to get an Exception
            List<double> foundNumbers = stringHelper.GetNumbersFromText();
            Console.WriteLine("Found Numbers:");
            foreach (var number in foundNumbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine($"\nSum = {stringHelper.FindSum()} Max Number = {stringHelper.FindMax()}, Index of max number {stringHelper.IndexOfMaxNumber()}");
        }
    }
}