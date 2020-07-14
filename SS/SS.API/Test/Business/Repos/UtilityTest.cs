using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Moq;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.Utility;
using SS.Business.Repos;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Data.Repos;
using Test.Business.ClassData;
using Test.Business.Interfaces;
using Xunit;

namespace Test.Business.Repos
{
    public class UtilityTest : IUtilityTest
    {
        [Theory]
        [ClassData(typeof(CityToCreateParamsData))]
        public async Task CreateCity(CityToCreateDto d)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var city = new City
                {
                    CityName = d.CityName,
                    StateId = d.StateId
                };
                // Expression<Func<City, bool>> ex = c => c.StateId == d.StateId && c.CityName == d.CityName;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUsCityData>().Setup(x => x.Find(ex)).Returns(Task.FromResult(city));
                var cityList = new List<City>();
                var matchingCities = cityList.AsEnumerable();
                var returnDto = new UsCityDto
                {
                    Name = d.CityName,
                    Id = d.StateId
                };

                mock.Mock<IMap>().Setup(x => x.MapToCity(d)).Returns(city);
                mock.Mock<IUsCityData>().Setup(x => x.FindManyAsync(It.IsAny<Expression<Func<City, bool>>>()))
                    .Returns(Task.FromResult(matchingCities));
                mock.Mock<IUsCityData>().Setup(x => x.Add(city));
                mock.Mock<IUsCityData>().Setup(x => x.SaveAllAsync()).Returns(Task.FromResult(true));
                mock.Mock<IMap>().Setup(x => x.MapToUsCityDto(city)).Returns(returnDto);

                var cls = mock.Create<UtilityRepo>();
                var expected = returnDto;
                var actual = await cls.CreateCityAsync(d);

                Assert.True(actual != null);
                Assert.Equal(actual, expected);
                // More Tests needed
            }
        }

        [Theory]
        [ClassData(typeof(UsZipCodeToCreateParamsData))]
        public async Task CreateZipCode(UsZipCodeToCreateDto d)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var zipCode = new ZipCode
                {
                    Digits = d.ZipCode,
                    CityId = d.CityId
                };
                // Expression<Func<ZipCode, bool>> ex = z => z.CityId == d.CityId && z.Digits == d.ZipCode;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUsZipCodeData>().Setup(x => x.Find(ex)).Returns(Task.FromResult(zipCode));
                var zipCodeList = new List<ZipCode>();
                var matchingZipCodes = zipCodeList.AsEnumerable();
                var returnDto = new UsZipCodeDto
                {
                    ZipCode = d.ZipCode,
                    Id = d.CityId
                };

                mock.Mock<IMap>().Setup(x => x.MapToZipCode(d)).Returns(zipCode);
                mock.Mock<IUsZipCodeData>().Setup(x => x.FindManyAsync(It.IsAny<Expression<Func<ZipCode, bool>>>()))
                    .Returns(Task.FromResult(matchingZipCodes));
                mock.Mock<IUsZipCodeData>().Setup(x => x.Add(zipCode));
                mock.Mock<IUsZipCodeData>().Setup(x => x.SaveAllAsync()).Returns(Task.FromResult(true));
                mock.Mock<IMap>().Setup(x => x.MapToUsZipCodeDto(zipCode)).Returns(returnDto);

                var cls = mock.Create<UtilityRepo>();
                var expected = returnDto;
                var actual = await cls.CreateZipCodeAsync(d);

                Assert.True(actual != null);
                Assert.Equal(actual, expected);
                // More Tests needed
            }
        }

        [Fact]
        public async Task GetCountries()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var country = new Country { CountryName = "CountryName" };
                var countries = new List<Country>();
                countries.Add(country);
                var eCountries = countries.AsEnumerable();
                var countryDto = new CountryDto { Name = "CountryName" };
                var dto = new List<CountryDto>();
                dto.Add(countryDto);

                mock.Mock<ICountryData>().Setup(x => x.GetAllAsync()).Returns(Task.FromResult(eCountries));
                mock.Mock<IMap>().Setup(x => x.MapToCountryDto(countries)).Returns(dto);

                var cls = mock.Create<UtilityRepo>();
                var expected = dto;
                var actual = await cls.GetCountriesAsync();

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
                // More Tests needed
            }
        }

        [Theory]
        [InlineData("CityName", 1)]
        public async Task CreateCityWithNameAndId(string name, int stateId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var toCreate = new CityToCreateDto()
                {
                    CityName = name,
                    StateId = stateId
                };
                var city = new City
                {
                    CityName = name,
                    StateId = stateId
                };

                // Expression<Func<City, bool>> ex = c => c.StateId == d.StateId && c.CityName == d.CityName;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUsCityData>().Setup(x => x.Find(ex)).Returns(Task.FromResult(city));
                var cityList = new List<City>();
                var matchingCities = cityList.AsEnumerable();
                var returnDto = new UsCityDto
                {
                    Name = name,
                    Id = stateId
                };

                // mock.Mock<IUtility>().Setup(x => x.CreateCityAsync(toCreate)).Returns(Task.FromResult(returnDto));
                mock.Mock<IMap>().Setup(x => x.MapToCity(toCreate)).Returns(city);
                // mock.Mock<IMap>().Setup(x => x.MapToCity(toCreate)).Returns(It.IsAny<City>);
                mock.Mock<IUsCityData>().Setup(x => x.FindManyAsync(It.IsAny<Expression<Func<City, bool>>>()))
                    .Returns(Task.FromResult(matchingCities));
                mock.Mock<IUsCityData>().Setup(x => x.Add(city));
                mock.Mock<IUsCityData>().Setup(x => x.SaveAllAsync()).Returns(Task.FromResult(true));
                mock.Mock<IMap>().Setup(x => x.MapToUsCityDto(city)).Returns(returnDto);

                var cls = mock.Create<UtilityRepo>();
                var expected = 1;
                var actual = await cls.CreateCityAsync(name, stateId);

                Assert.True(actual != null);
                Assert.Equal(actual, expected);
                // More Tests needed
            }
        }

        [Theory]
        [InlineData("99999", 1)]
        public async Task CreateZipCodeWithNameAndId(string zipCodeDigits, int cityId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var cls = mock.Create<UtilityRepo>();
                var expected = 1;
                var actual = await cls.CreateCityAsync(zipCodeDigits, cityId);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task GetUsCities(int usStateId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var usCity = new City { CityName = "CityName" };
                var usCities = new List<City>();
                usCities.Add(usCity);
                var eUsCities = usCities.AsEnumerable();
                var usCityDto = new UsCityDto { Name = "CityName" };
                var dto = new List<UsCityDto>();
                dto.Add(usCityDto);

                // Expression<Func<City, bool>> ex = c => c.StateId == usStateId;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUsCityData>().Setup(x => x.FindManyAsync(ex)).Returns(Task.FromResult(eUsCities));

                mock.Mock<IUsCityData>().Setup(x => x.FindManyAsync(It.IsAny<Expression<Func<City, bool>>>()))
                    .Returns(Task.FromResult(eUsCities));
                mock.Mock<IMap>().Setup(x => x.MapToUsCityDto(usCities)).Returns(dto);

                var cls = mock.Create<UtilityRepo>();
                var expected = dto;
                var actual = await cls.GetUsCitiesAsync(usStateId);

                Assert.True(actual != null);
                Assert.Equal(expected.FirstOrDefault().Name, actual.FirstOrDefault().Name);
                // More Tests needed
            }
        }

        [Fact]
        public async Task GetUsStates()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var usState = new Usstate { StateName = "StateName" };
                var usStates = new List<Usstate>();
                usStates.Add(usState);
                var eUsStates = usStates.AsEnumerable();
                var usStateDto = new UsStateDto { Name = "StateName" };
                var dto = new List<UsStateDto>();
                dto.Add(usStateDto);

                mock.Mock<IUsStateData>().Setup(x => x.GetAllAsync()).Returns(Task.FromResult(eUsStates));
                mock.Mock<IMap>().Setup(x => x.MapToUsStateDto(usStates)).Returns(dto);

                var cls = mock.Create<UtilityRepo>();
                var expected = dto;
                var actual = await cls.GetUsStatesAsync();

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
                // More Tests needed
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task GetZipCodes(int usCityId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var usZipCode = new ZipCode { Digits = "99999" };
                var usZipCodes = new List<ZipCode>();
                usZipCodes.Add(usZipCode);
                var eZipCodes = usZipCodes.AsEnumerable();
                var usZipCodeDto = new UsZipCodeToReturnDto { ZipCode = "99999" };
                var dto = new List<UsZipCodeToReturnDto>();
                dto.Add(usZipCodeDto);

                // Expression<Func<ZipCode, bool>> ex = c => c.CityId == usCityId;
                // // would like to test with ^^this^^ but don't think I'm able to
                // mock.Mock<IUsZipCodeData>().Setup(x => x.FindManyAsync(ex)).Returns(Task.FromResult(eZipCodes));

                mock.Mock<IUsZipCodeData>().Setup(x => x.FindManyAsync(It.IsAny<Expression<Func<ZipCode, bool>>>()))
                    .Returns(Task.FromResult(eZipCodes));
                mock.Mock<IMap>().Setup(x => x.MapToUsZipCodeDto(usZipCodes)).Returns(dto);

                var cls = mock.Create<UtilityRepo>();
                var expected = dto;
                var actual = await cls.GetZipCodesAsync(usCityId);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
                // More Tests needed
            }
        }
    }
}