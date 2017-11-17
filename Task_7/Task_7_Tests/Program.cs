using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_7;

namespace Task_7_Tests
{ 
    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void ToString_FormatNRIsCorrect()
        {
            var customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

            string strExpected = "Jeffrey Richter, 1000000";

            Assert.That(customer.ToString("nr"), Is.EqualTo(strExpected));
        }

        [Test]
        public void ToString_EmptyStringGivesCorrectResult()
        {
            var customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

            string strExpected = "Jeffrey Richter, +1 (425) 555-0100, 1000000";

            Assert.That(customer.ToString(""), Is.EqualTo(strExpected));
        }
    }

    [TestFixture]
    public class TitleCaseTest
    {
        [TestCase("A Clash of Kings", "a clash of KINGS", "a an the of")]
        [TestCase("The Wind in the Willows", "THE WIND IN THE WILLOWS", "The In")]
        [TestCase("The Quick Brown Fox", "the quick brown fox")]
        public void ConvertIntoTitleCase_Test(string strExpected, string phrase, string listOfMinorWords = "")
        {
            var titleCase = new TitleCase();

            string str = titleCase.ConvertIntoTitleCase(phrase, listOfMinorWords);

            Assert.That(str, Is.EqualTo(strExpected));
        }
    }

    [TestFixture]
    public class UrlParameterTest
    {
        [TestCase("www.example.com", "key=value", "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", "www.example.com?key=newValue")]
        [TestCase("www.example.com?key=oldValue&key2=value2", "key=newValue", "www.example.com?key=newValue&key2=value2")]
        public void AddOrChangeUrlParameter_Test(string url, string keyValueParameter, string urlExpected)
        {
            var urlParameter = new UrlParameter();

            string urlNew = urlParameter.AddOrChangeUrlParameter(url, keyValueParameter);

            Assert.That(urlNew, Is.EqualTo(urlExpected));
        }
    }

    [TestFixture]
    public class UniqueSymbolTest
    {
        [TestCase("AAAABBBCCDAABBB", "ABCDAB")]
        [TestCase("ABBCcAD", "ABCcAD")]
        [TestCase("12233", "123")]
        public void UniqueInOrder_Test(IEnumerable<char> sequence, string sequenceExpected)
        {
            var uniqueSymbol = new UniqueSymbol();

            string sequenceNew = uniqueSymbol.UniqueInOrder(sequence);

            Assert.That(sequenceNew, Is.EqualTo(sequenceExpected));
        }

        [Test]
        public void UniqueInOrder_TestForList()
        {
            var uniqueSymbol = new UniqueSymbol();

            string sequenceNew = uniqueSymbol.UniqueInOrder(new List<char> { 'a', 'b', 'b', 'c' });

            Assert.That(sequenceNew, Is.EqualTo("abc"));
        }
    }

    [TestFixture]
    public class WordsReversationTest
    {
        [TestCase("The greatest victory is that which requires no battle", "battle no requires which that is victory greatest The")]
        [TestCase("", "")]
        public void ReverseWords_Test(string phrase, string phraseExpected)
        {
            var wordsReversation = new WordsReversation();

            string phraseNew = wordsReversation.ReverseWords(phrase);

            Assert.That(phraseNew, Is.EqualTo(phraseExpected));
        }
    }

    [TestFixture]
    public class SummatorTest
    {
        [TestCase("13", "29", "42")]
        [TestCase("123456789123456789123456789", "987654321987654321987654321", "1111111111111111111111111110")]
        [TestCase("777", "0", "777")]
        public void Sum_Test(string number1, string number2, string resultExpected)
        {
            var summator = new Summator();

            string result = summator.Sum(number1, number2);

            Assert.That(result, Is.EqualTo(resultExpected));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
