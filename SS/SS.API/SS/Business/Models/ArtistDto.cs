using System;

namespace SS.Business.Models
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public DateTime? CareerEndDate { get; set; }
        public bool Group { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int HomeCountryId { get; set; }
        public int? HomeUsStateId { get; set; }
        public int? HomeUsCityId { get; set; }
        public int? HomeUsZipCodeId { get; set; }
        public int? HomeWorldRegionId { get; set; }
        public int? HomeWorldCityId { get; set; }
        public int CurrentCountryId { get; set; }
        public int? CurrentUscityId { get; set; }
        public int? CurrentWorldCityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        //        
        public int? YearsActive { get; set; }
    }
}