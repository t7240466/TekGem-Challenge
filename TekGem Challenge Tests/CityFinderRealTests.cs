using CitySearch;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TekGem_Challenge;

namespace TekGem_Challenge_Tests
{
    public class CityFinderRealTests
    {
        private CityFinder realCityFinder;
        private SortedCityData realCityData;

        [OneTimeSetUp]
        public void Setup()
        {
            //Setup real resources
            realCityData = new SortedCityData();
            realCityFinder = new CityFinder(realCityData.GetCities());
        }

        [Test]
        public void CityFinderTests_SearchSpeedInitialCharacter()
        {
            //Execute function
            var results = this.realCityFinder.Search("b");

            //Assert
            Assert.Pass();
        }

        [Test]
        public void CityFinderTests_SearchSpeedPartialWord()
        {
            //Execute function
            var results = this.realCityFinder.Search("bor");

            //Assert
            Assert.Pass();
        }

        [Test]
        public void CityFinderTests_SearchSpeedFullProcess()
        {
            //Execute function
            var results = this.realCityFinder.Search("b");
            results = this.realCityFinder.Search("bo");
            results = this.realCityFinder.Search("bor");
            results = this.realCityFinder.Search("borh");
            results = this.realCityFinder.Search("borha");
            results = this.realCityFinder.Search("borhan");

            //Assert
            Assert.Pass();
        }
    }
}