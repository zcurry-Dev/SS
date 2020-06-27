using System.ComponentModel.DataAnnotations;

namespace SS.Business.Dtos.Accept
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