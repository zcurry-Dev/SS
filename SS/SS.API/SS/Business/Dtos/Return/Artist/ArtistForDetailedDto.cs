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
        public int? HomeCountryId { get; set; }
        public int? HomeCityId { get; set; }
        public string HomeCity { get; set; }
        public int? CurrentCountryId { get; set; }
        public int? CurrentCityId { get; set; }
        public string CurrentCity { get; set; }
        public DateTime CreatedDate { get; set; }
        // public int MainPhotoId { get; set; }
        // public List<int> PhotoIds { get; set; }
        // public IEnumerable<PhotoforReturnDto> Photos { get; set; }
    }
}