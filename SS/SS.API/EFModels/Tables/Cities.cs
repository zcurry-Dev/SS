using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Cities
    {
        public Cities()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
    }
}
