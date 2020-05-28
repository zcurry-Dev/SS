using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class ArtistPhoto
    {
        public int ArtistPhotoId { get; set; }
        public int ArtistId { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoDescription { get; set; }
        public string PhotoFileContentType { get; set; }
        public string PhotoFileExt { get; set; }
        public string PhotoFileName { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
