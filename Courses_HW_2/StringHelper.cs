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
//2.    Дан текст, в начале которого имеются пробелы и в котором имеются цифры. Найти порядковый номер максимальной цифры,
//начиная счет с первого символа, не являющегося пробелом. Если максимальных цифр несколько, то должен быть найден номер первой из них.

namespace Courses_HW_2
{
    internal class StringHelper
    {
        private string _text;
        public StringHelper(string text)
        {
            _text = text;
        }
        public string Text { get => _text; set => _text = value; }
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
        /// <summary>
        ///  Will find any numbers including integers and doubles from text
        /// </summary>
        /// <returns>Array of numbers</returns>
        public List<double> GetNumbersFromText() 
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
        /// <summary>
        /// Perfectly works with integer numbers, is not going to work text number like 50000,,,,,,,,,,,,,23 because pattern wont match parsed number 
        /// </summary>
        /// <returns>First index of max number</returns>
        public int IndexOfMaxNumber()         {
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
            if (match.Success)
            {
                return match.Index - countSpacesAtStart;
            }
            return -1;
        } 
    }
}
