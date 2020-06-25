using System.Collections.Generic;
using SS.Business.Models;

namespace SS.Business.Dtos.Return
{
    public class CountriesToReturnDto
    {
        public IEnumerable<CountryBModel> Countries { get; set; }
    }
}