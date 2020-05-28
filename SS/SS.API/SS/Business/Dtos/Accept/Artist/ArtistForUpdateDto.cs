using System;

namespace SS.Business.Dtos.Accept
{
    public class ArtistForUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public bool Group { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int HomeCountryId { get; set; }
        public int? UshomeCityId { get; set; }
        public int? WorldHomeCityId { get; set; }
        public int? CurrentCityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}