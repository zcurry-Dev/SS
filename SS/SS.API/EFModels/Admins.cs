using System;
using System.Collections.Generic;

namespace SS.API.EFModels
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

        public Users User { get; set; }
        public ICollection<AdminRolesXref> AdminRolesXref { get; set; }
    }
}
