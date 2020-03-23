﻿using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class ArtistTypes
    {
        public ArtistTypes()
        {
            ArtistGroupMembers = new HashSet<ArtistGroupMembers>();
            ArtistTypeXref = new HashSet<ArtistTypeXref>();
        }

        public int ArtistTypeId { get; set; }
        public string ArtistType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employees CreatedByNavigation { get; set; }
        public virtual ICollection<ArtistGroupMembers> ArtistGroupMembers { get; set; }
        public virtual ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
