using System.ComponentModel.DataAnnotations;

namespace SS.Business.Models.Utility
{
    public class UsCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClosestMajorCityId { get; set; }
        public bool MajorCity { get; set; }
    }

    // Accept
    public class CityToCreateDto
    {
        [Required]
        public string CityName { get; set; }
        public int? ClosestMajorCityId { get; set; }

        [Required]
        public int StateId { get; set; }
    }
}