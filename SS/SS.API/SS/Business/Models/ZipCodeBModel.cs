namespace SS.Business.Models
{
    public class ZipCodeBModel
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
    }
}