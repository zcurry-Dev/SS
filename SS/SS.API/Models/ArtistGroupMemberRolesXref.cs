using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class ArtistGroupMemberRolesXref
    {
        public int ArtistGroupMemberRolesXrefId { get; set; }
        public int ArtistGroupMemberId { get; set; }
        public int ArtistGroupMemberRoleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ArtistGroupMembers ArtistGroupMember { get; set; }
        public virtual ArtistGroupMemberRoles ArtistGroupMemberRole { get; set; }
    }
}
