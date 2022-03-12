using Autocomplete.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autocomplete.Business.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ObterEnderecoPorCidadeAsync(FiltroViewModel filtro);

    }
}
