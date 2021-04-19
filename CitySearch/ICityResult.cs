﻿using System.Collections.Generic;

namespace CitySearch
{
    public interface ICityResult
    {
        ICollection<string> NextLetters { get; set; }
        ICollection<string> NextCities { get; set; }
    }
}
