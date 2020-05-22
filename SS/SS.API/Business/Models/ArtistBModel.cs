using System;
using System.Collections.Generic;

namespace SS.API.Business.Models
{
    public class ArtistBModel
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistStatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public bool ArtistGroup { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int? HomeCity { get; set; }
        public int? CurrentCity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ArtistPhotoBModel> ArtistPhotos { get; set; }
    }
}