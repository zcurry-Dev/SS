namespace SS.Business.Models
{
    public class RoleBModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; } //needed? 062820
    }
}