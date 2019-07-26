using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class UserStatuses
    {
        public UserStatuses()
        {
            Users = new HashSet<Users>();
        }

        public int UserStatusId { get; set; }
        public string UserStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
