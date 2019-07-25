using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class UserStatuses
    {
        public UserStatuses()
        {
            Ssusers = new HashSet<Ssusers>();
        }

        public int UserStatusId { get; set; }
        public string UserStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Ssusers> Ssusers { get; set; }
    }
}
