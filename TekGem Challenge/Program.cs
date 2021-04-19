using System;

namespace TekGem_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Allows the console to output the non-standard characters found in city names
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Instantiate CityFinder
            SortedCityData cityData = new SortedCityData();
            CityFinder cityFinder = new CityFinder(cityData.GetCities());

            Console.WriteLine("Type a word and press the enter key to start searching for cities");
            Console.WriteLine("Result city counts are shown for performance reasons for counts over 25");
            Console.WriteLine("Enter 1 to end the program");
            Console.WriteLine("Enter 2 to reset the word");

            string entry = "";

            //Simulate program running and search entry
            while (true)
            {
                //Collect input
                var key = Console.ReadKey();

                if (Char.IsLetterOrDigit(key.KeyChar))
                {
                    if (!Char.IsDigit(key.KeyChar))
                    {
                        entry += key.Key.ToString();
                    }

                    Console.WriteLine("");
                    Console.WriteLine("KEY IS: " + key.Key.ToString());

                    //Should the program continue?
                    if (key.Key.ToString() == "D1")
                    {
                        //End program by leaving loop
                        break;
                    }
                    else if (key.Key.ToString() == "D2")
                    {
                        entry = "";
                        Console.WriteLine("Reset search term");
                    }
                    else
                    {
                        //Search for cities using input
                        var result = cityFinder.Search(entry);

                        if (result != null)
                        {
                            if (result.NextCities.Count < 25)
                            {
                                string nextLetters = "";
                                string nextCities = "";

                                foreach (string letter in result.NextLetters)
                                {
                                    nextLetters += letter + " ";
                                }

                                foreach (string city in result.NextCities)
                                {
                                    nextCities += city + " ";
                                }

                                //Output search results
                                Console.WriteLine("");
                                Console.WriteLine("Cities: " + nextCities);
                                Console.WriteLine("Letters: " + nextLetters);
                                Console.WriteLine(entry);
                            }
                            else
                            {
                                //Only show count for performance reasons

                                string nextLetters = "";

                                foreach (string letter in result.NextLetters)
                                {
                                    nextLetters += letter + " ";
                                }

                                //Output search results
                                Console.WriteLine("");
                                Console.WriteLine("Cities: " + result.NextCities.Count);
                                Console.WriteLine("Letters: " + nextLetters);
                                Console.WriteLine(entry);
                            }
                        }
                        else
                        {
                            //Output for lack of results
                            Console.WriteLine("");
                            Console.WriteLine("No results found for that search term");
                        }
                    }
                }
            }

            //Program End
        }
    }
}
