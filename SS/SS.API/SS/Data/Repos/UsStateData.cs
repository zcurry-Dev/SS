using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class UsStateData : DataRepo<Usstate>, IUsStateData
    {
        public UsStateData(DataContext context) : base(context) { }
    }
}