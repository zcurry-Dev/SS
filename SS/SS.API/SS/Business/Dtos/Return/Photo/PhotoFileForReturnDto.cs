namespace SS.Business.Dtos.Return
{
    public class PhotoFileForReturnDto
    {
        public byte[] File { get; set; }
        public string PhotoFileContentType { get; set; }
        public string PhotoFileName { get; set; }
    }
}