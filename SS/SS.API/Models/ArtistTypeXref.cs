using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class ArtistTypeXref
    {
        public int ArtistTypeXrefId { get; set; }
        public int ArtistId { get; set; }
        public int ArtistTypeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Artists Artist { get; set; }
        public virtual ArtistTypes ArtistType { get; set; }
    }
}
