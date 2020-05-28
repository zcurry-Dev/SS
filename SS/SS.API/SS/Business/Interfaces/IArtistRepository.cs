using System.Threading.Tasks;
using SS.API.Business.Dtos.Accept;
using SS.API.Business.Dtos.Return;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Business.Interfaces
{
    public interface IArtistRepository
    {
        Task<ArtistForDetailedDto> CreateArtist(ArtistToCreate artistToCreate);
        Task<ArtistForDetailedDto> GetArtistById(int artistId);
        Task<ArtistListForReturnDto> GetArtists(ArtistParams artistParams);
        Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto);

        //
        // Photo methods
        //
        Task<PhotoFileForReturnDto> GetArtistPhotoFileByPhotoId(int photoId);
        Task<bool> UploadPhoto(int artistId, PhotoForCreationDto photoForCreationDto);
        Task<PhotoforReturnDto> GetMostRecentArtistPhoto(int artistId);
        Task<bool> SetNewMainPhoto(PhotoIds photoIds);
        Task<bool> DeletePhoto(int artistPhotoId);
        Task<PhotoforReturnDto> GetArtistPhotoByPhotoId(int photoId);
        //
    }
}