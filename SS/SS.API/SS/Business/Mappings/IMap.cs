using System.Collections.Generic;
using SS.Business.Models.Artist;
using SS.Business.Models.Role;
using SS.Business.Models.User;
using SS.Business.Models.Utility;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Mappings
{
    public interface IMap
    {
        // Admin
        PagedListDto<UserWithRolesDto> MapToUserWithRolesDto(PagedListData<Ssuser> pl);
        IEnumerable<RoleDto> MapToRoleDto(IEnumerable<Ssrole> ssroles);

        // Artist        
        void Update(ArtistForUpdateDto a, Artist artist);
        Artist MapToArtist(ArtistToCreateDto a);
        ArtistDetailDto MapToArtistDetailDto(Artist a);
        PagedListDto<ArtistForListDto> MapToArtistForListDto(PagedListData<Artist> pl);

        // User        
        UserDto MapToUserForDetailDto(Ssuser Ssuser);
        Ssuser MapToSsuser(UserForRegisterDto user);

        // Utility
        IEnumerable<CountryDto> MapToCountryDto(IEnumerable<Country> countryList);
        IEnumerable<UsStateDto> MapToUsStateDto(IEnumerable<Usstate> stateList);
        City MapToCity(CityToCreateDto c);
        IEnumerable<UsCityDto> MapToUsCityDto(IEnumerable<City> cityList);
        UsCityDto MapToUsCityDto(City c);
        IEnumerable<UsZipCodeToReturnDto> MapToUsZipCodeDto(IEnumerable<ZipCode> zipCodeList);
        ZipCode MapToZipCode(UsZipCodeToCreateDto z);
        UsZipCodeDto MapToUsZipCodeDto(ZipCode z);
    }
}