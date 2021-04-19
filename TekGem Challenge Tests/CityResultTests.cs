using CitySearch;
using NUnit.Framework;
using System.Collections.Generic;
using TekGem_Challenge;

namespace TekGem_Challenge_Tests
{
    public class CityResultTests
    {
        private CityResult cityResult;
        private ICollection<string> cities;
        private ICollection<string> letters;

        [SetUp]
        public void Setup()
        {
            cities = new List<string> { "Manchester", "Leeds", "Newcastle" };
            letters = new List<string> { "a", "e", "u" };
            this.cityResult = new CityResult(letters, cities);
        }

        [Test]
        public void CityResultTests_ICityResultInstance()
        {
            //Assert
            Assert.IsInstanceOf<ICityResult>(this.cityResult);
        }

        [Test]
        public void CityResultTests_NextCitiesInstance()
        {
            //Assert
            Assert.IsInstanceOf<ICollection<string>>(this.cityResult.NextCities);
            Assert.AreEqual(this.cities, this.cityResult.NextCities);
        }

        [Test]
        public void CityResultTests_NextLettersInstance()
        {
            //Assert
            Assert.IsInstanceOf<ICollection<string>>(this.cityResult.NextLetters);
            Assert.AreEqual(this.letters, this.cityResult.NextLetters);
        }
    }
}