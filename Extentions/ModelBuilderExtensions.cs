using Autocomplete.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Autocomplete.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"world-cities_csv.csv");
            string[] files = File.ReadAllLines(path);
            var list = new List<City>();
            foreach (var item in files)
            {
                list.Add(new City(item));
            }
            
            modelBuilder.Entity<City>()
                .HasData(list);
        }
    }
}
