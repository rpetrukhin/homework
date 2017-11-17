using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    public class Customer
    {
        private string _name;
        private string _contactPhone;
        private decimal _revenue;

        public Customer(string name, string contactPhone, decimal revenue)
        {
            _name = name;
            _contactPhone = contactPhone;
            _revenue = revenue;
        }

        public override string ToString()
        {
            return ToString("cnr");
        }

        public string ToString(string format)
        {
            switch(format.ToLower())
            {
                case "n":
                    return _name;
                case "c":
                    return _contactPhone;
                case "r":
                    return _revenue.ToString();
                case "nc":
                    return String.Format("{0}, {1}", _name, _contactPhone);
                case "nr":
                    return String.Format("{0}, {1}", _name, _revenue);
                case "cr":
                    return String.Format("{0}, {1}", _contactPhone, _revenue);
                case "cnr":
                    return String.Format("{0}, {1}, {2}", _name, _contactPhone, _revenue);
                default:
                    return String.Format("{0}, {1}, {2}", _name, _contactPhone, _revenue);
            }
        }
    }

    public class TitleCase
    {
        public string ConvertIntoTitleCase(string phrase, string listOfMinorWords = "")
        {
            phrase = phrase.ToLower();

            string[] wordsOfPhrase = phrase.Split();
            string[] minorWords = listOfMinorWords.Split();

            for (int i = 0; i < wordsOfPhrase.Length; i++)
                wordsOfPhrase[i] = String.Concat(Char.ToUpper(wordsOfPhrase[i][0]), wordsOfPhrase[i].Substring(1));

            for (int i = 1; i < wordsOfPhrase.Length; i++)
                for (int j = 0; j < minorWords.Length; j++)
                    if (String.Equals(wordsOfPhrase[i], minorWords[j], StringComparison.OrdinalIgnoreCase))
                        wordsOfPhrase[i] = wordsOfPhrase[i].ToLower();

            string phraseOut = String.Join(" ", wordsOfPhrase);

            return phraseOut;
        }
    }

    public class UrlParameter
    {
        public string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            var st = new StringBuilder();
            st.Append(url);

            if (!url.Contains('?'))
            {
                st.Append('?');
                st.Append(keyValueParameter);
                return st.ToString();
            }

            string key = keyValueParameter.Substring(0, keyValueParameter.IndexOf("="));

            if (url.Contains(key))
            {
                if (url.IndexOf("&", url.IndexOf(key)) > 0)
                    return st.Replace(url.Substring(url.IndexOf(key), url.IndexOf("&", url.IndexOf(key)) - url.IndexOf(key)), keyValueParameter).ToString();
                else
                    return st.Replace(url.Substring(url.IndexOf(key)), keyValueParameter).ToString();
            }
            else
            {
                st.Append('&');
                st.Append(keyValueParameter);
                return st.ToString();
            }
        }
    }

    public class UniqueSymbol
    {
        public string UniqueInOrder(IEnumerable<char> sequence) 
        {
            var sb = new StringBuilder();
            foreach(char symbol in sequence)
            {
                sb.Append(symbol);
            }

            int i = 1;
            while (i < sb.Length)
            {
                if (sb[i - 1] == sb[i])
                {
                    sb.Remove(i, 1);
                    i--;
                }
                i++;
            }

            return sb.ToString();
        }
    }

    public class WordsReversation
    {
        public string ReverseWords(string phrase)
        {
            string[] s = phrase.Split();

            Array.Reverse(s);

            return String.Join(" ", s);
        }
    }

    public class Summator
    {
        //Only for positive numbers
        public string Sum(string number1, string number2)
        {
            if (number1[0] == '-' || number2[0] == '-')
                throw new Exception("Input of negative number(s)");

            const int numberOfDigits = 9;
            var sb = new StringBuilder();
            int reserve = 0;

            if (number2.Length > number1.Length)
            {
                string s = number1;
                number1 = number2;
                number2 = s;
            }

            int i;
            long a1;
            long a2;
            for (i = 1; i * numberOfDigits < number2.Length; i++)
            {
                Console.WriteLine("first iterration");
                a1 = Convert.ToInt64(number1.Substring(number1.Length - i * numberOfDigits, numberOfDigits));
                a2 = Convert.ToInt64(number2.Substring(number2.Length - i * numberOfDigits, numberOfDigits));

                sb.Insert(0, a1 + a2 + reserve);

                if (sb.Length == (i * numberOfDigits + 1))
                {
                    reserve = 1;
                    sb.Remove(0, 1);
                }
                else
                    reserve = 0;

                Console.WriteLine(sb);
            }

            a2 = Convert.ToInt64(number2.Substring(0, number2.Length - (i - 1) * numberOfDigits));

            int j;
            for (j = i; j * numberOfDigits < number1.Length; j++)
            {
                Console.WriteLine("Second iteration");
                a1 = Convert.ToInt64(number1.Substring(number1.Length - j * numberOfDigits, numberOfDigits));

                sb.Insert(0, a1 + a2 + reserve);

                if (sb.Length == (j * numberOfDigits + 1))
                {
                    reserve = 1;
                    sb.Remove(0, 1);
                }
                else
                    reserve = 0;

                if (j == i)
                    a2 = 0;

                Console.WriteLine(sb);
            }

            a1 = Convert.ToInt64(number1.Substring(0, number1.Length - (j - 1) * numberOfDigits));
            sb.Insert(0, a1 + a2 + reserve);

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}