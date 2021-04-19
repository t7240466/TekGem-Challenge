using CitySearch;
using System.Collections.Generic;

namespace TekGem_Challenge
{
    public class CityResult : ICityResult
    {
        public ICollection<string> NextLetters { get; set; }
        public ICollection<string> NextCities { get; set; }

        public CityResult(ICollection<string> letters, ICollection<string> cities)
        {
            NextLetters = letters;
            NextCities = cities;
        }
    }
}
