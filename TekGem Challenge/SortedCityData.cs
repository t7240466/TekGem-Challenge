using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TekGem_Challenge
{
    public class SortedCityData
    {
        private IDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>> cities;

        public SortedCityData()
        {
            this.cities = new SortedDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>>();

            this.InitiateData();
        }

        public IDictionary<string, IDictionary<DictionaryKeys, ICollection<string>>> GetCities()
        {
            return this.cities;
        }

        //Initial adding of data to the sorted collection
        private void InitiateData()
        {
            //Load city data from file
            StreamReader reader = new StreamReader(File.OpenRead(".\\Real City Data.csv"));

            Console.WriteLine("Loading Cities...");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().ToLower();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    var entry = line.Split(";");
                    var key = entry[1].Substring(0, 1);

                    if (!this.cities.ContainsKey(key))
                    {
                        this.cities.Add(key, new Dictionary<DictionaryKeys, ICollection<string>>());
                        this.cities[key].Add(DictionaryKeys.Cities, new List<string>());
                        this.cities[key].Add(DictionaryKeys.Letters, new List<string>());
                    }

                    var letter = "";
                    var city = entry[1];
                    if (city.Length > 1)
                    {
                        letter = city.Substring(1, 1);
                        if (!this.cities[key][DictionaryKeys.Letters].Contains(letter))
                        {
                            this.cities[key][DictionaryKeys.Letters].Add(letter);
                        }
                    }
                    this.cities[key][DictionaryKeys.Cities].Add(city);

                    //Enabling drastically increases load times
                    //Console.WriteLine("Key: " + key + " City: " + city + " NextLetter: " + letter);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Sorting item lists...");

            //Sort each list
            foreach (KeyValuePair<string, IDictionary<DictionaryKeys, ICollection<string>>> entry in this.cities)
            {
                List<string> item1 = (List<string>)this.cities[entry.Key][DictionaryKeys.Cities];
                item1.Sort();
                this.cities[entry.Key][DictionaryKeys.Cities] = item1;

                List<string> item2 = (List<string>)this.cities[entry.Key][DictionaryKeys.Letters];
                item2.Sort();
                this.cities[entry.Key][DictionaryKeys.Letters] = item2;
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
