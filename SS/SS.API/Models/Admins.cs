using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Admins
    {
        public Admins()
        {
            AdminRolesXref = new HashSet<AdminRolesXref>();
        }

        public int AdminId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<AdminRolesXref> AdminRolesXref { get; set; }
    }
}
