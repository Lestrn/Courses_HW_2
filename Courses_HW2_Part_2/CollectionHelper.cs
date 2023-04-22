using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//3.      Дан массив, в котором хранится информация о количестве страниц в каждой из 100 книг. Все страницы имеют одинаковую толщину. Определить количество страниц в самой толстой книге.
//4.      В массиве хранится информация о максимальной скорости каждой из 40 марок легковых автомобилей. Определить порядковый номер самого быстрого автомобиля. Если таких автомобилей несколько, то должен быть найден номер:
//а) первого из них;
//б) последнего из них.
namespace Courses_HW2_Part_2
{
    internal static class CollectionHelper
    {
        public static (string book, int amountOfPages) FindTheThickestBook(Dictionary<string, int> booksPages)
        {
            var result = booksPages.FirstOrDefault(x => x.Value == booksPages.Values.Max()); ;
            return (result.Key, result.Value);
        }
        public static (int first, int last) IndexOfFastestCar(Dictionary<string, int> carsSpeeds)
        {
            List<int> speeds = carsSpeeds.Values.ToList();
            var carWithMaxSpeed = speeds.Max(value => value);
            if (speeds == null)
            {
                return (-1, -1);
            }
            var result = speeds.Where(value => value == carWithMaxSpeed);
            int firstIndex, lastIndex = -1;
            firstIndex = speeds.IndexOf(result.First());
            if (result.Count() > 2)
            {
                lastIndex = speeds.IndexOf(result.Last());
                return (firstIndex, lastIndex);
            }
            return (firstIndex, lastIndex);
        }
    }
}
