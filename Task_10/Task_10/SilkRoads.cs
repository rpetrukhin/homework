using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_10
{
    public class SilkRoads
    {
        public Dictionary<string, int> DetermineFrequencyOfOccurrencesOfWords(string fileName)
        {
            var sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(fileName))
            {
                sb.Append(sr.ReadToEnd());
            }

            if (sb.Capacity == 0)
                return null;

            sb.Replace(',', ' ');
            sb.Replace('.', ' ');
            sb.Replace(':', ' ');
            sb.Replace('“', ' ');
            sb.Replace('”', ' ');
            sb.Replace('(', ' ');
            sb.Replace(')', ' ');
            sb.Replace('[', ' ');
            sb.Replace(']', ' ');

            string[] words = sb.ToString().ToLower().Split();

            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!dictionary.ContainsKey(words[i]))
                    dictionary.Add(words[i], 1);
                else
                    dictionary[words[i]]++;
            }

            return dictionary;
        }
    }
}