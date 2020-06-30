using System.ComponentModel.DataAnnotations;

namespace SS.Business.Models.Utility
{
    public class CityToCreateDto
    {
        [Required]
        public string CityName { get; set; }
        public int? ClosestMajorCityId { get; set; }

        [Required]
        public int StateId { get; set; }
    }
}