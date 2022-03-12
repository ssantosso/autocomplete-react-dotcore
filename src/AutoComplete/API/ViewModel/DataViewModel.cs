using System.Collections.Generic;

namespace Autocomplete.API.ViewModel
{
    public class DataViewModel
    {
        public IEnumerable<CityViewModel> citys { get; set; }
        public IEnumerable<string> sugestions { get; set; }
    }
}
