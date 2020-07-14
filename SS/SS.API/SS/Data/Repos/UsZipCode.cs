using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UsZipCodeData : DataRepo<ZipCode>, IUsZipCodeData
    {
        public UsZipCodeData(DataContext context) : base(context) { }
    }
}