using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class CityZipcodeXref
    {
        public int CityZipcodeXrefId { get; set; }
        public int ZipCode { get; set; }

        public ZipCodes ZipCodeNavigation { get; set; }
    }
}
