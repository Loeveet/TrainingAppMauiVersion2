using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Singletons;

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

        public static string CapitalizeFirstLetter(string word)
        {
            if (word == "" || word == null) return "All";
            string fixedWord = char.ToUpper(word[0]) + word.Substring(1).Replace('_', ' ');
            return fixedWord;
        }
        public static string FixWordsForApi(string word)
        {
            if (word == string.Empty || word == null) return "All";
            string newWord = word.ToLower().Replace(' ', '_');
            return newWord;
        }

        public static double TryParseToDouble(string input)
        {
            double id;

            if (!double.TryParse(input, out id))
            {
                return 0;
            }
            return id;
        }
    }
}
