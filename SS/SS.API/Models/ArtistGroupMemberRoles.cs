using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class ArtistGroupMemberRoles
    {
        public ArtistGroupMemberRoles()
        {
            ArtistGroupMemberRolesXref = new HashSet<ArtistGroupMemberRolesXref>();
        }

        public int ArtistGroupMemberRoleId { get; set; }
        public string ArtistGroupMemberRole { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employees CreatedByNavigation { get; set; }
        public virtual ICollection<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
    }
}
