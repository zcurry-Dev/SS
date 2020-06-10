using System.Collections.Generic;
using SS.Business.Models;

namespace SS.Business.Dtos.Return
{
    public class UsStatesToReturnDto
    {
        public IEnumerable<UsStateBModel> UsStates { get; set; }
    }
}