using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class ArtistGroupMember
    {
        public ArtistGroupMember()
        {
            ArtistGroupMemberRolesXref = new HashSet<ArtistGroupMemberRolesXref>();
        }

        public int ArtistGroupMemberId { get; set; }
        public int ArtistId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ArtistType Artist { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual ICollection<ArtistGroupMemberRolesXref> ArtistGroupMemberRolesXref { get; set; }
    }
}
