using System.ComponentModel.DataAnnotations;

namespace SS.Business.Models.Utility
{
    public class ZipCodeToCreateDto
    {
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "ZipCode must be 5 characters ")]
        public string ZipCode { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}