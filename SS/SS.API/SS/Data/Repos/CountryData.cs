using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class CountryData : DataRepo<Country>, ICountryData
    {
        public CountryData(DataContext context) : base(context) { }
    }
}