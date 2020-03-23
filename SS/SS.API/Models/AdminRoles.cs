﻿using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class AdminRoles
    {
        public AdminRoles()
        {
            AdminRolesXref = new HashSet<AdminRolesXref>();
        }

        public int AdminRoleId { get; set; }
        public string AdminRole { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<AdminRolesXref> AdminRolesXref { get; set; }
    }
}
