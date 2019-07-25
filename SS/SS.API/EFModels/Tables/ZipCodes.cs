using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class ZipCodes
    {
        public ZipCodes()
        {
            Addresses = new HashSet<Addresses>();
            CityZipcodeXref = new HashSet<CityZipcodeXref>();
        }

        public int ZipCode { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
        public ICollection<CityZipcodeXref> CityZipcodeXref { get; set; }
    }
}
