using System;
using System.Collections.Generic;
using SS.API.Models;

namespace SS.API.Dtos
{
    public class ArtistForDetailedDto
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistStatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public int YearsActive { get; set; }
        public bool Solo { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<ArtistPhotosForDetailedDto> Photos { get; set; }
    }
}