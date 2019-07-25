﻿using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Admins
    {
        public Admins()
        {
            AdminRolesXref = new HashSet<AdminRolesXref>();
        }

        public int AdminId { get; set; }
        public int SsuserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Ssusers Ssuser { get; set; }
        public ICollection<AdminRolesXref> AdminRolesXref { get; set; }
    }
}
