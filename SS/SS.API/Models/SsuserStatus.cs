using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SsuserStatus
    {
        public SsuserStatus()
        {
            Ssuser = new HashSet<Ssuser>();
        }

        public int UserStatusId { get; set; }
        public string UserStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Ssuser> Ssuser { get; set; }
    }
}
