using CitySearch;
using System;
using System.Collections.Generic;

namespace TekGem_Challenge
{
    //This implementation of ICityFinder assumes that city finder is only called
    //on the submition of a search term by the user or after a pause in input
    //as such it searches the entire data set each time as the search term
    //may become less specific or change entirely
    public class CityFinder : ICityFinder
    {
        private IDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>> citiesData { get; set; }

        public CityFinder(IDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>> cityData)
        {
            this.citiesData = cityData;
        }

        public ICityResult Search(string searchString)
        {
            //Check search term is valid
            if (!string.IsNullOrEmpty(searchString))
            {
                //Get key for the largest subset of data
                searchString = searchString.ToLower();
                string key = searchString.Substring(0, 1);
                var cities = citiesData;

                if (cities != null && cities.ContainsKey(key))
                {
                    try
                    {
                        ICollection<string> nextLetters;
                        ICollection<string> keyCities;
                        var length = searchString.Length;

                        //There is code repitition however, if entry if the first character subset needn't
                        //be created again preventing n operations where n is the cities for that first letter
                        //and prevent n if statement checks that would be required for cleaner code
                        if (length == 1)
                        {
                            nextLetters = cities[key][DictionaryKeys.Letters];
                            keyCities = cities[key][DictionaryKeys.Cities];
                            return new CityResult(nextLetters, keyCities);
                        }
                        else
                        {
                            //Initial size is given as Lists use arrays and if they must expand beyond there limit
                            //they create another larger intstance and copy each over resulting in more operations
                            //and temporary memory usage as the arrays are copied
                            nextLetters = new List<string>();
                            keyCities = cities[key][DictionaryKeys.Cities];
                            ICollection<string> nextCities = new List<string>(keyCities.Count);

                            //Look at all cities, add if relevant and get next letter
                            foreach (string city in keyCities)
                            {
                                if (city.StartsWith(searchString))
                                {
                                    nextCities.Add(city);

                                    //Ensure current city has more letters for suggestion
                                    if (length < city.Length)
                                    {
                                        var letter = city.Substring(length, 1);

                                        //Add next letter if not already in list
                                        if (!nextLetters.Contains(letter))
                                        {
                                            nextLetters.Add(letter);
                                        }
                                    }
                                }
                            }

                            return new CityResult(nextLetters, nextCities);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                }
            }

            return null;
        }
    }
}
