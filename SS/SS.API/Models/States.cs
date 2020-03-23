using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class States
    {
        public States()
        {
            Addresses = new HashSet<Addresses>();
            Cities = new HashSet<Cities>();
        }

        public int StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Cities> Cities { get; set; }
    }
}
