using System;

namespace SS.API.Business.Dtos.Accept
{
    public class ArtistToCreate
    {
        public ArtistToCreate()
        {
            var now = DateTime.Now;

            CareerBeginDate = now;
            ArtistGroup = false;
            Verified = false;
            HomeCountryId = 1; //United States defaulted for now, will use form data
            CreatedBy = 1; // me for now, will use token identity instead
            CreatedDate = now;
        }

        public string Name { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public bool ArtistGroup { get; set; }
        public bool Verified { get; set; }
        public int HomeCountryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}