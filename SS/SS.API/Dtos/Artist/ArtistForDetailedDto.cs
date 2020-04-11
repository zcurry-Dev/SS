using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SS.API.Models;

namespace SS.API.Dtos
{
    public class ArtistForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public int YearsActive { get; set; }
        public bool Solo { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public string CurrentCity { get; set; }
        public string HomeCity { get; set; }
        public int PhotoId { get; set; }
        public ICollection<ArtistPhotosForDetailedDto> Photos { get; set; }
    }
}