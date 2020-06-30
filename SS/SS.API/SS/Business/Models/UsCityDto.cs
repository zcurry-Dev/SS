namespace SS.Business.Models
{
    public class UsCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClosestMajorCityId { get; set; }
        public int StateId { get; set; }
        public bool MajorCity { get; set; }
    }
}