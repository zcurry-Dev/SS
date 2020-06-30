using SS.Business.Mappings.Interfaces;
using SS.Business.Models.User;
using SS.Data.Models;

namespace SS.Business.Mappings.Repos
{
    public class UserMapping : IUserMapping
    {
        public UserForDetailDto MapToUserForDetailDto(Ssuser u)
        {
            var user = new UserForDetailDto()
            {
                Id = u.Id,
                // Id = u.UserId, // "u.UserId is always 0" -z 062820
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                DateOfBirth = u.DateOfBirth,
                Created = u.CreatedDate,
                LastActive = u.LastActive,
                UserName = u.UserName,
                DisplayName = u.DisplayName,
            };

            return user;
        }

        public Ssuser MapToSsuser(UserForRegisterDto u)
        {
            var user = new Ssuser()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                CreatedDate = u.Created,
                LastActive = u.LastActive, //does this break? 062820
                UserName = u.UserName
            };

            return user;
        }
    }
}