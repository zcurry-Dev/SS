using System.ComponentModel.DataAnnotations;

namespace SS.Business.Models.Utility
{
    public class WorldRegionDto
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // Accept
    public class WorldRegionToCreateDto
    {
    }

    // Return
    public class WorldRegionToReturnDto
    {
    }
}