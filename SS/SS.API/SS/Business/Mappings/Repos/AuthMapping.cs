using SS.Business.Dtos.Return;
using SS.Business.Mappings.Interfaces;
using SS.Data.Models;

namespace SS.Business.Mappings.Repos
{
    public class AuthMapping : IAuthMapping
    {
        public Ssuser MapToSsuser(UserForDetailDto u)
        {
            var user = new Ssuser()
            {
                Id = u.Id,
                UserId = u.Id, // not sure which is used more or by default 062820
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                DateOfBirth = u.DateOfBirth,
                CreatedDate = u.Created,
                LastActive = u.LastActive,
                UserName = u.UserName,
                DisplayName = u.DisplayName
            };

            return user;
        }
    }
}