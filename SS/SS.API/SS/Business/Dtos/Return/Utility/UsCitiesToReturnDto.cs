using System.Collections.Generic;
using SS.Business.Models;

namespace SS.Business.Dtos.Return
{
    public class UsCitiesToReturnDto
    {
        public IEnumerable<UsCityBModel> UsCities { get; set; }
    }
}