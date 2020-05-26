using System;

namespace SS.API.Business.Dtos.Return
{
    public class PhotoforReturnDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string PhotoDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}