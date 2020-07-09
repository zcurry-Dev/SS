using System.Collections;
using System.Collections.Generic;
using SS.Business.Models.User;
using SS.Business.Pagination;

namespace Test.Business.ClassData
{
    public class AdminUsersParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new AdminUsersParams()
                    {
                        PN = 1,
                        IPP = 10,
                        OrderBy = "",
                        Search = ""
                    }
                };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}