using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class States
    {
        public States()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
    }
}
