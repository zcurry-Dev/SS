using System.ComponentModel.DataAnnotations;

namespace SS.Business.Models.Utility
{
    public class ZipCodeDto
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
    }

    // Accept
    public class ZipCodeToCreateDto
    {
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "ZipCode must be 5 characters ")]
        public string ZipCode { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    // Return
    public class ZipCodeToReturnDto
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
    }
}