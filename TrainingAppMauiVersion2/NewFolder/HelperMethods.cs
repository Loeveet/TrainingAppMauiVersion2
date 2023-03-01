using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.NewFolder
{
    class HelperMethods
    {
        public static string[] CapitalizeFirstLetterInArray(string[] array)
        {
            string[] arrayForShow = new string[array.Length];
            int i = 0;
            foreach (var item in array)
            {
                char first = item[0];
                arrayForShow[i] = char.ToUpper(item[0]) + item.Substring(1).Replace('_', ' ');
                i++;
            }
            return arrayForShow;
        }
        public static double ConvertKgToPounds(double kg)
        {
            double pounds = kg * 2.2046226218;
            return Math.Round(pounds);
        }
        public static int TryParseToInt(string input)
        {
            int id;
            while (!int.TryParse(input, out id))
            {
                Console.WriteLine("Wrong input, try again");
                input = Console.ReadLine();
            }
            return id;
        }
    }
}
