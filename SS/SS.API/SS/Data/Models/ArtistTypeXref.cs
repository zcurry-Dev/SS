using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class ArtistTypeXref
    {
        public int ArtistTypeXrefId { get; set; }
        public int ArtistId { get; set; }
        public int ArtistTypeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ArtistType ArtistType { get; set; }
    }
}
