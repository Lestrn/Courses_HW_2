using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//1.Дан текст, в котором присутствуют цифры. Требуется
// а) Найти их сумму.
// б) Определить максимальную цифру.
//2.      Дан текст, в начале которого имеются пробелы и в котором имеются цифры. Найти порядковый номер максимальной цифры, начиная счет с первого символа, не являющегося пробелом. Если максимальных цифр несколько, то должен быть найден номер первой из них.
//3.      Дан массив, в котором хранится информация о количестве страниц в каждой из 100 книг. Все страницы имеют одинаковую толщину. Определить количество страниц в самой толстой книге.
//4.      В массиве хранится информация о максимальной скорости каждой из 40 марок легковых автомобилей. Определить порядковый номер самого быстрого автомобиля. Если таких автомобилей несколько, то должен быть найден номер:
//а) первого из них;
//б) последнего из них.

namespace Courses_HW_2
{
    internal class StringHelper
    {
        private string _text;
        public StringHelper(string text)
        {
            _text = text;
        }
        public double FindSum()
        {
            List<double> numbers = GetNumbersFromText();
            if (numbers.Count == 0)
            {
                return 0;
            }
            return numbers.Sum(x => x);
        }
        public double FindMax()
        {
            List<double> numbers = GetNumbersFromText();
            if(numbers.Count == 0)
            {
                return 0;
            }
            return numbers.Max(x => x);
        }
        public List<double> GetNumbersFromText() // Will find not only integers but also doubles
        {
            string processedText = _text;
            processedText = Regex.Replace(processedText, @"[^0-9.,]+", "|"); // Remove every char that is not related to numbers (except , . and numbers)      
            processedText = Regex.Replace(processedText, @"[^0-9|]+", ","); //Removing repeatable . and , so if  text is ....,,,,,, will be replaced with just ,
            Match[] numbersWithComas = Regex.Matches(processedText, @"([0-9]+,[0-9]+)").ToArray(); // Find all numbers with comas
            processedText = Regex.Replace(processedText, @"([0-9]+,[0-9]+)", ""); // Remove them
            processedText = Regex.Replace(processedText, @"\|+|,+", "|"); // Remove "splitters" comas that left
            List<string> unparsedNumbersWithoutComas = processedText.Split('|').ToList(); // Split to get an array
            unparsedNumbersWithoutComas = unparsedNumbersWithoutComas.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();  // Get rid of empty values
            List<double> numbers = new List<double>(5); // Save all numbers
            foreach (var item in numbersWithComas)
            {
                numbers.Add(double.Parse(item.ToString()));
            }
            foreach (var unparsedNumber in unparsedNumbersWithoutComas)
            {
                numbers.Add(double.Parse(unparsedNumber));
            }                 
            return numbers;
        }
        public int IndexOfMaxNumber() // Perfectly works with integer numbers, is not going to work text number like 50000,,,,,,,,,,,,,23 because pattern wont match parsed number
        {
            int countSpacesAtStart = 0;
            for (int i = 0; i < _text.Length; i++)
            {
                if (_text[i] == ' ')
                {
                    countSpacesAtStart++;
                }
                else
                {
                    break;
                }
            }
            double maxNumber = FindMax();
            Match match = Regex.Match(_text, maxNumber.ToString());
            return match.Index - countSpacesAtStart;
        } 
    }
}
