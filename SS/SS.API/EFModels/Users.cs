using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class Users
    {
        public Users()
        {
            Admins = new HashSet<Admins>();
            UserEmployeeXref = new HashSet<UserEmployeeXref>();
            UserRolesXref = new HashSet<UserRolesXref>();
            Venues = new HashSet<Venues>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserStatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserStatuses UserStatus { get; set; }
        public ICollection<Admins> Admins { get; set; }
        public ICollection<UserEmployeeXref> UserEmployeeXref { get; set; }
        public ICollection<UserRolesXref> UserRolesXref { get; set; }
        public ICollection<Venues> Venues { get; set; }
    }
}
