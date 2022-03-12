using Autocomplete.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autocomplete.Business.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCityByFilterAsync(FiltroViewModel filtro);
        Task<IEnumerable<City>> GetAll();

    }
}
