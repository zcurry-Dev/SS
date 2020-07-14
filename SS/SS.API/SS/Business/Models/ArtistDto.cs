using System;

namespace SS.Business.Models.Artist
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
    }

    public class ArtistDetailDto : ArtistDto
    {
        public int? YearsActive { get; set; }
    }

    // Accept
    public class ArtistToCreateDto
    {
        public ArtistToCreateDto()
        {
            var now = DateTime.Now;

            CareerBeginDate = now;
            ArtistGroup = false;
            Verified = false;
            HomeCountryId = 1; //United States defaulted for now, will use form data
            CurrentCountryId = 1; //United States defaulted for now, will use form data
            CreatedBy = 1; // me for now, will use token identity instead
            CreatedDate = now;
        }

        public string Name { get; set; }
        public DateTime CareerBeginDate { get; }
        public bool ArtistGroup { get; }
        public bool Verified { get; }
        public int HomeCountryId { get; }
        public int CurrentCountryId { get; }
        public int CreatedBy { get; }
        public DateTime CreatedDate { get; }
    }

    public class ArtistForUpdateDto : ArtistDto
    {
        public string HomeUsCity { get; set; }
        public string HomeUsZipcode { get; set; }
        public string HomeWorldRegion { get; set; }
        public string HomeWorldCity { get; set; }
    }

    // Return
    public class ArtistForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ArtistStatusId { get; set; }
        public int? YearsActive { get; set; }
        public bool ArtistGroup { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public string MainPhotoId { get; set; }
        public string CurrentCity { get; set; }
        public string HomeCity { get; set; }
    }
}