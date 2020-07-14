using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface ICountryData : IDataRepo<Country> { }
    public interface IUsStateData : IDataRepo<Usstate> { }
    public interface IUsCityData : IDataRepo<City> { }
    public interface IUsZipCodeData : IDataRepo<ZipCode> { }
    public interface IUserRoleData : IDataRepo<Ssrole> { }
}