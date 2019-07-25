using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class ArtistGroupMembers
    {
        public ArtistGroupMembers()
        {
            ArtistGroupMemberRolesXref = new HashSet<ArtistGroupMemberRolesXref>();
        }

        public int ArtistGroupMemberId { get; set; }
        public int ArtistId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public ArtistTypes Artist { get; set; }
        public ICollection<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
    }
}
