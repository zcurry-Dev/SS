using System;
using System.Collections.Generic;
using SS.API.Business.Dtos.Photo;

namespace SS.API.Business.Dtos.Artist
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistStatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public bool Solo { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int? HomeCity { get; set; }
        public int? CurrentCity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ArtistPhotoDto> ArtistPhotos { get; set; }
    }
}