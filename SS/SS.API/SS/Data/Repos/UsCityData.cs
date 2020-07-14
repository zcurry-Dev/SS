using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UsCityData : DataRepo<City>, IUsCityData
    {
        public UsCityData(DataContext context) : base(context) { }
    }
}