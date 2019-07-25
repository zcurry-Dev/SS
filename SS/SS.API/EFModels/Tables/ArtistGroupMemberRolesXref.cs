using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class ArtistGroupMemberRolesXref
    {
        public int ArtistGroupMemberRolesXrefId { get; set; }
        public int ArtistGroupMemberId { get; set; }
        public int ArtistGroupMemberRoleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public ArtistGroupMembers ArtistGroupMember { get; set; }
        public ArtistGroupMemberRoles ArtistGroupMemberRole { get; set; }
    }
}
