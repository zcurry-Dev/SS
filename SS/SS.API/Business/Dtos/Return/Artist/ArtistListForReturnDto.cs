using System.Collections.Generic;

namespace SS.API.Business.Dtos.Return
{
    public class ArtistListForReturnDto
    {
        public IEnumerable<ArtistForListDto> Artists { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}