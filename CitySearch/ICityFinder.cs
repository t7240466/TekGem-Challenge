using System.Collections.Generic;

namespace CitySearch
{
    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }
}
