using System.Threading.Tasks;
using AutoMapper;
using SS.API.Business.Dtos.User;
using SS.API.Business.Interfaces;
using SS.API.Data.Interfaces;

namespace SS.API.Business.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDataRepository _user;
        private readonly IMapper _mapper;

        public UserRepository(IUserDataRepository user, IMapper mapper)
        {
            _mapper = mapper;
            _user = user;
        }

        public async Task<UserForDetailDto> GetUser(int userId)
        {
            var ssUser = await _user.GetUserById(userId.ToString());
            var userToReturn = _mapper.Map<UserForDetailDto>(ssUser);

            return userToReturn;
        }
    }
}