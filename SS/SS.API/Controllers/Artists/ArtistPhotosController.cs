using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.API.Business.Dtos.Photo;
using SS.API.Business.Interfaces;

namespace SS.API.Controllers
{
    [Route("api/artists/{artistId}/photos")]
    [ApiController]
    public class ArtistPhotosController : ControllerBase
    {
        private readonly IArtistRepository _artist;

        public ArtistPhotosController(IArtistRepository artist)
        {
            _artist = artist;
        }

        // [HttpGet("{id}", Name = "GetArtistPhoto")]
        // public async Task<IActionResult> GetArtistPhoto(int id)
        // {
        //     var photo = await _artist.GetArtistPhotoByPhotoId(id);

        //     return Ok(photo);
        // }

        // [HttpPost]
        // public async Task<IActionResult> AddPhotoForArtist(int artistId,
        //     [FromForm]PhotoForCreationDto photoForCreationDto)
        // {
        //     var result = await _artist.UploadPhoto(artistId, photoForCreationDto);

        //     if (result)
        //     {
        //         var photoToReturn = _artist.GetMostRecentArtistPhoto(artistId);
        //         return CreatedAtRoute(
        //             "GetArtistPhoto",
        //             new { artistId = artistId, id = photoToReturn.Id },
        //             photoToReturn);
        //     }

        //     return BadRequest("Could not add the photo");
        // }

        // [HttpPost("{photoId}/setMain")]
        // public async Task<IActionResult> SetMainPhoto(int artistId, int photoId)
        // {
        //     var artist = await _artist.GetArtistById(artistId);
        //     if (!artist.Photos.Any(p => p.Id == photoId))
        //     {
        //         return Unauthorized();
        //     }

        //     var photoFromRepo = await _artist.GetArtistPhotoByPhotoId(photoId);
        //     if (photoFromRepo.IsMain)
        //     {
        //         return BadRequest("This is already the main photo");
        //     }

        //     var result = await _artist.SetNewMainPhoto(artistId, photoId);

        //     if (result)
        //     {
        //         return NoContent();
        //     }

        //     return BadRequest("Could not set photo to main");
        // }

        // [HttpDelete("{photoId}")]
        // public async Task<IActionResult> DeletePhoto(int artistId, int photoId)
        // {
        //     var artist = await _artist.GetArtistById(artistId);
        //     if (!artist.Photos.Any(p => p.Id == photoId))
        //     {
        //         return Unauthorized();
        //     }

        //     var photoFromRepo = await _artist.GetArtistPhotoByPhotoId(photoId);
        //     if (photoFromRepo.IsMain)
        //     {
        //         return BadRequest("You cannot delete your main photo");
        //     }

        //     //
        //     // DELETE FILE FROM SYSTEM
        //     //
        //     //

        //     // if file deleted "OK"
        //     // if (result.Result == "ok") {} then 

        //     var result = await _artist.DeletePhoto(photoId);
        //     if (result)
        //     {
        //         return Ok();
        //     }

        //     return BadRequest("Failed to delete the photo");

        // }
    }
}