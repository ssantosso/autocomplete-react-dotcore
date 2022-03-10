using Autocomplete.Business.Interface;
using Autocomplete.Business.Models;
using Autocomplete.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;

namespace Autocomplete.Business.Service
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<City>> ObterPorFiltroAsync(FiltroViewModel filtro)
        {
            var files = ObterRegistros();

            var list = await Task.Factory.StartNew(() => files.Select(x => new City(x))
                    .Where(x =>
                            string.IsNullOrEmpty(filtro.Filtro) || x.Original.Contains(filtro.Filtro)
                        )
                    .OrderBy(x => x.name)

                .ToList());

            return list;
        }

        public async Task<IEnumerable<City>> ObterEnderecoPorCidadeAsync(FiltroViewModel filtro)
        {
            var files = ObterRegistros();

            var list = await Task.Factory.StartNew(() => files.Select(x => new City(x))
                    .Where(x =>
                            string.IsNullOrEmpty(filtro.Filtro) || x.Original.Contains(filtro.Filtro)
                        )
                    .OrderBy(x => x.name)

                .ToList().Take(50).ToList());

            return list;
        }

        private IList<string> ObterRegistros()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"world-cities_csv.csv");
            var files = File.ReadAllLines(path);
            return files.Distinct().Where(x=> !string.IsNullOrEmpty(x)&& x.Split(",").Count()==4).ToList();
        }
    }
}
