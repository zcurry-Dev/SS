namespace SS.Business.Models
{
    public class ZipCodeDto
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
    }
}