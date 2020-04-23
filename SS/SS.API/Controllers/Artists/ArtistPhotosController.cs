using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SS.API.Data;
using SS.API.Data.Interfaces;
using SS.API.Dtos;
using SS.API.Dtos.Photo;
using SS.API.Models;

namespace SS.API.Controllers
{
    [Route("api/artists/{artistId}/photos")]
    [ApiController]
    public class ArtistPhotosController : ControllerBase
    {
        private readonly IArtistRepository _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public ArtistPhotosController(IArtistRepository repo, IMapper mapper, IConfiguration config)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet("{id}", Name = "GetArtistPhoto")]
        public async Task<IActionResult> GetArtistPhoto(int id)
        {
            var photoFromRepo = await _repo.GetArtistPhoto(id);
            var photo = _mapper.Map<PhotoforReturnDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForArtist(int artistId,
            [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            var photo = await _repo.UploadPhoto(artistId, photoForCreationDto);

            if (await _repo.SaveAll())
            {
                // return Ok();
                var photoToReturn = _mapper.Map<PhotoforReturnDto>(photo);
                return CreatedAtRoute(
                    "GetArtistPhoto",
                    new { artistId = artistId, id = photo.ArtistPhotoId },
                    photoToReturn);
            }

            return BadRequest("Could not add the photo");
        }

        [HttpPost("{photoId}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int artistId, int photoId)
        {
            var artist = await _repo.GetArtist(artistId);
            if (!artist.ArtistPhoto.Any(p => p.ArtistPhotoId == photoId))
            {
                return Unauthorized();
            }

            var photoFromRepo = await _repo.GetArtistPhoto(photoId);

            if (photoFromRepo.IsMain)
            {
                return BadRequest("This is already the main photo");
            }

            var currentMainPhoto = await _repo.GetMainPhotoForArtist(artistId);
            currentMainPhoto.IsMain = false;
            photoFromRepo.IsMain = true;

            if (await _repo.SaveAll())
            {
                return NoContent();
            }

            return BadRequest("Could not set photo to main");
        }

        [HttpDelete("{photoId}")]
        public async Task<IActionResult> DeletePhoto(int artistId, int photoId)
        {
            var artist = await _repo.GetArtist(artistId);
            if (!artist.ArtistPhoto.Any(p => p.ArtistPhotoId == photoId))
            {
                return Unauthorized();
            }

            var photoFromRepo = await _repo.GetArtistPhoto(photoId);

            if (photoFromRepo.IsMain)
            {
                return BadRequest("You cannot delete your main photo");
            }


            //
            // DELETE FILE FROM SYSTEM
            //
            //

            // if file deleted "OK"
            // if (result.Result == "ok") {} then 
            _repo.Delete(photoFromRepo);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to delete the photo");

        }
    }
}