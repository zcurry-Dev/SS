using System;

namespace SS.Business.Models.Artist
{
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
        public DateTime CareerBeginDate { get; set; }
        public bool ArtistGroup { get; set; }
        public bool Verified { get; set; }
        public int HomeCountryId { get; set; }
        public int CurrentCountryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}