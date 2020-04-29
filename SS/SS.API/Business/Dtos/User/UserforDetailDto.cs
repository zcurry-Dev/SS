using System;

namespace SS.API.Business.Dtos.User
{
    public class UserForDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }
}