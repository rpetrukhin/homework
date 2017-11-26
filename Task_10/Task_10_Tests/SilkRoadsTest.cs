using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task_10;

namespace Task_10_Tests
{
    [TestFixture]
    public class SilkRoadsTest
    {
        [Test]
        public void DetermineFrequencyOfOccurrencesOfWords_Test()
        {
            var silkroads = new SilkRoads();

            var dictionary = silkroads.DetermineFrequencyOfOccurrencesOfWords("SilkRoads.txt");

            Assert.That(dictionary["countries"], Is.EqualTo(8));
            Assert.That(dictionary["russia"], Is.EqualTo(7));
            Assert.That(dictionary["for"], Is.EqualTo(27));
        }
    }
}