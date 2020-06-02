namespace SS.Business.Dtos.Return
{
    public class ArtistForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ArtistStatusId { get; set; }
        public int YearsActive { get; set; }
        public bool ArtistGroup { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public string MainPhotoId { get; set; }
        public string CurrentCity { get; set; }
        public string HomeCity { get; set; }
    }
}