using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Ssusers
    {
        public Ssusers()
        {
            Admins = new HashSet<Admins>();
            SsusersEmployeeXref = new HashSet<SsusersEmployeeXref>();
            UserRolesXref = new HashSet<UserRolesXref>();
            Venues = new HashSet<Venues>();
        }

        public int SsuserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserStatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserStatuses UserStatus { get; set; }
        public ICollection<Admins> Admins { get; set; }
        public ICollection<SsusersEmployeeXref> SsusersEmployeeXref { get; set; }
        public ICollection<UserRolesXref> UserRolesXref { get; set; }
        public ICollection<Venues> Venues { get; set; }
    }
}
