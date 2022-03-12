using Autocomplete.Business.Interface;
using Autocomplete.Business.Models;
using Autocomplete.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;

namespace Autocomplete.Business.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(MeuDbContext context) : base(context) { }


        public async Task<IEnumerable<City>> ObterEnderecoPorCidadeAsync(FiltroViewModel filtro)
        {
            var files = ObterRegistros();

            var list = await Task.Factory.StartNew(() => files.Select(x => new City(x))
                    .Where(x =>
                            x.IsOk() && (string.IsNullOrEmpty(filtro.Filtro?.Trim()) || x.original.ToLower().Contains(filtro.Filtro?.ToLower()))
                        )
                    .OrderBy(x => x.original)

                .Take(50).ToList());

            return list;
        }

        private IList<string> ObterRegistros()
        {

            string path = Path.Combine(Environment.CurrentDirectory, @"world-cities_csv.csv");
            if (!File.Exists(path))
                return new List<string>();
            
            var files = File.ReadAllLines(path);
            return files.Distinct().Where(x => !string.IsNullOrEmpty(x) && x.Split(",").Count() == 4).ToList();
        }
    }
}
