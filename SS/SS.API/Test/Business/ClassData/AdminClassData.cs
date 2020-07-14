using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SS.Business.Models.User;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace Test.Business.ClassData
{
    public class AdminClassData
    {
        public PagedListData<Ssuser> CreatePagedList()
        {
            var users = new List<Ssuser> {
                    new Ssuser {UserName = "First"},
                    new Ssuser {UserName = "Second"}
                };
            return new PagedListData<Ssuser>(users, 100, 1, 10);
        }

        public PagedListDto<UserWithRolesDto> CreatePagedListDto()
        {
            var pl = CreatePagedList();
            var items = pl.Select(u => new UserWithRolesDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Roles = u.SsuserRole.Select(r => r.Role.ToString()).ToList(),
            }).ToList();

            return new PagedListDto<UserWithRolesDto>(items);
        }
    }

    public class AdminUsersParamsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new AdminUsersParams
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