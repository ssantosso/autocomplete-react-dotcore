using Autocomplete.API.ViewModel;
using Autocomplete.Business.Models;
using AutoMapper;
using System;

namespace Autocomplete.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<City, CityViewModel>().ReverseMap();
            //CreateMap<string, City>()
            //    .ForMember(p => p, opts => opts.MapFrom(s => MapString(s)));

        }

        private City MapString(string s)
        {
            return new City(s.Split(","));
        }
    }
}
