using System;
using System.Collections.Generic;
using SS.API.Models;

namespace SS.API.Dtos.Artist
{
    public class ArtistForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ArtistStatusId { get; set; }
        public int YearsActive { get; set; }
        public bool Solo { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public string PhotoId { get; set; }
        public string CurrentCity { get; set; }
        public string HomeCity { get; set; }
    }
}