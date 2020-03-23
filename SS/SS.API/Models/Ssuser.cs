using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Ssuser
    {
        public Ssuser()
        {
            ArtistGroupMemberRole = new HashSet<ArtistGroupMemberRole>();
            Ssadmin = new HashSet<Ssadmin>();
            UserEmployeeXref = new HashSet<UserEmployeeXref>();
            UserRolesXref = new HashSet<UserRolesXref>();
            Venue = new HashSet<Venue>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] PwHash { get; set; }
        public byte[] PwSalt { get; set; }

        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<ArtistGroupMemberRole> ArtistGroupMemberRole { get; set; }
        public virtual ICollection<Ssadmin> Ssadmin { get; set; }
        public virtual ICollection<UserEmployeeXref> UserEmployeeXref { get; set; }
        public virtual ICollection<UserRolesXref> UserRolesXref { get; set; }
        public virtual ICollection<Venue> Venue { get; set; }
    }
}
