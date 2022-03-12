using Autocomplete.Business.Models;
using Autocomplete.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Autocompletetest
{
    public class CityTests
    {
        

        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityEmptyWhenNameHasNoValue()
        {
            //Arrange
            var filtro = ",No name,No name,134567";
            var city = new CityRepository();
            
            //Act
            var list =  await city.GetCityByFilterAsync(new FiltroViewModel {Filtro= filtro });


            //Assert

            Assert.Empty(list);
        }

        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityEmptyWhenCountryHasNoValue()
        {
            //Arrange
            var filtro = "No country,,No country,No country";
            var city = new CityRepository();

            //Act
            var list = await city.GetCityByFilterAsync(new FiltroViewModel { Filtro = filtro });


            //Assert

            Assert.Empty(list);
        }

        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityEmptyWhenSubCountryHasNoValue()
        {
            //Arrange
            var filtro = "No subcountry,No subcountry,,No subcountry";
            var city = new CityRepository();

            //Act
            var list = await city.GetCityByFilterAsync(new FiltroViewModel { Filtro = filtro });


            //Assert

            Assert.Empty(list);
        }

        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityEmptyWhenGeoNameIdHasNoValue()
        {
            //Arrange
            var filtro = "No geo,No geo,No geo";
            var city = new CityRepository();

            //Act
            var list = await city.GetCityByFilterAsync(new FiltroViewModel { Filtro = filtro });


            //Assert

            Assert.Empty(list);
        }
        
        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityEmptyWhenRegisterHasMoreColumn()
        {
            //Arrange
            var filtro = "Amarillis,teste,teste,123,";
            var city = new CityRepository();

            //Act
            var list = await city.GetCityByFilterAsync(new FiltroViewModel { Filtro = filtro });


            //Assert

            Assert.Empty(list);
        }

        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityHasRegistreWhenFilterNull()
        {
            //Arrange
            FiltroViewModel filtro = null;
            var city = new CityRepository();

            //Act
            var list = await city.GetCityByFilterAsync(filtro);

            //Assert
            Assert.True(list?.Any());
        }

        [Fact]
        public async void CityRepository_GetCityByFilterAsync_ResultCityHasRegistreWhenFilterDefaault()
        {
            //Arrange
            FiltroViewModel filtro = new FiltroViewModel();
            var city = new CityRepository();

            //Act
            var list = await city.GetCityByFilterAsync(filtro);


            //Assert
            Assert.True(list?.Any());
        }
        
    }
}
