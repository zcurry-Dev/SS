using System;
using System.Collections.Generic;

namespace SS.Business.Dtos.Return
{
    public class ArtistForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public int YearsActive { get; set; }
        public bool ArtistGroup { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int HomeCountryId { get; set; }
        public int HomeRegionId { get; set; }
        public int HomeCityId { get; set; }
        public int CurrentCountryId { get; set; }
        public int? CurrentRegionId { get; set; }
        public int? CurrentCityId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}