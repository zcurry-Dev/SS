using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class ArtistTypeXref
    {
        public int ArtistTypeXrefId { get; set; }
        public int ArtistId { get; set; }
        public int ArtistTypeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Artists Artist { get; set; }
        public ArtistTypes ArtistType { get; set; }
    }
}
