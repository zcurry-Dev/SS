using System;
using System.Collections.Generic;

namespace SS.API.Models
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

        public virtual UserStatuses UserStatus { get; set; }
        public virtual ICollection<Admins> Admins { get; set; }
        public virtual ICollection<UserEmployeeXref> UserEmployeeXref { get; set; }
        public virtual ICollection<UserRolesXref> UserRolesXref { get; set; }
        public virtual ICollection<Venues> Venues { get; set; }
    }
}
