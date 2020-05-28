using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class ArtistGroupMemberRole
    {
        public ArtistGroupMemberRole()
        {
            ArtistGroupMemberRolesXref = new HashSet<ArtistGroupMemberRolesXref>();
        }

        public int ArtistGroupMemberRoleId { get; set; }
        public string ArtistGroupMemberRole1 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual ICollection<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
    }
}
