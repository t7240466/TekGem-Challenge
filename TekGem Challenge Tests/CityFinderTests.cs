using CitySearch;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TekGem_Challenge;

namespace TekGem_Challenge_Tests
{
    public class CityFinderTests
    {
        private CityFinder cityFinder;
        private IDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>> citiesData;

        [SetUp]
        public void Setup()
        {
            //Setup fake resources
            citiesData = new SortedDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>>();
            citiesData.Add("a", new Dictionary<DictionaryKeys, ICollection<string>>());
            citiesData["a"][DictionaryKeys.Cities] = new List<string> { "abby", "adom", "azeeza" };
            citiesData["a"][DictionaryKeys.Letters] = new List<string> { "b", "d", "z" };
            citiesData.Add("b", new Dictionary<DictionaryKeys, ICollection<string>>());
            citiesData["b"][DictionaryKeys.Cities] = new List<string> { "babby", "badom", "bazeeza" };
            citiesData["b"][DictionaryKeys.Letters] = new List<string> { "a" };
            citiesData.Add("c", new Dictionary<DictionaryKeys, ICollection<string>>());
            citiesData["c"][DictionaryKeys.Cities] = new List<string> { "cabby", "cadom", "cazeeza" };
            citiesData["c"][DictionaryKeys.Letters] = new List<string> { "a" };
            cityFinder = new CityFinder(citiesData);
        }

        [Test]
        public void CityFinderTests_ICityFinderInstance()
        {
            //Assert
            Assert.IsInstanceOf<ICityFinder>(this.cityFinder);
        }

        [Test]
        public void CityFinderTests_SearchResultsInstance()
        {
            //Execute function
            var results = cityFinder.Search("a");

            //Assert
            Assert.IsInstanceOf<CityResult>(results);
            Assert.IsInstanceOf<ICollection<string>>(results.NextCities);
            Assert.IsInstanceOf<ICollection<string>>(results.NextLetters);
        }

        [Test]
        public void CityFinderTests_SearchResultsData()
        {
            //Setup expected
            List<string> expectedCities = new List<string> { "abby", "adom", "azeeza" };
            List<string> expectedLetters = new List<string> { "b", "d", "z" };

            //Execute function
            var results = cityFinder.Search("a");

            //Assert
            Assert.AreEqual(results.NextCities, expectedCities);
            Assert.AreEqual(results.NextLetters, expectedLetters);
        }
    }
}