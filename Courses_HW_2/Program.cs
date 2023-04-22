namespace Courses_HW_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StringHelper stringHelper = new StringHelper("     ,543Hel50000,2lo! Today i would like to add 5 and 10 and 5,5 and 5.5 lol why not xD also i want to type some  comas" +
                "to break ur program ,,,,,,,, and points cuz why not.... and some stupid50000,2 numbers 11,,,,,12 13..14 15gg ,52"); // Was trying to find every possible way to get an Exception
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