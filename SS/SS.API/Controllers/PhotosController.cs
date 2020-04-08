using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SS.API.Data;
using SS.API.Dtos;
using SS.API.Models;

namespace SS.API.Controllers
{
    [Authorize]
    [Route("api/artists/{artistId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IArtistRepository _repo;
        private readonly IMapper _mapper;

        public PhotosController(IArtistRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto2(id);

            var photo = _mapper.Map<PhotoforReturnDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForArtist(int artistId,
            [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            string filePath = @"X:/uploadedImages/";
            // string filePath = Directory.GetCurrentDirectory();
            string uploadedImagesPathForArtist = filePath + @"artists/" + artistId + "/";

            if (!Directory.Exists(uploadedImagesPathForArtist))
            {
                Directory.CreateDirectory(uploadedImagesPathForArtist);
            }

            uploadedImagesPathForArtist += photoForCreationDto.File.FileName;

            using (var stream = new FileStream(uploadedImagesPathForArtist, FileMode.Create))
            {
                await photoForCreationDto.File.CopyToAsync(stream);
            }

            var artistFromRepo = await _repo.GetArtist(artistId);

            var file = photoForCreationDto.File;
            var photo = _mapper.Map<ArtistPhoto>(photoForCreationDto);
            photo.PhotoPath = uploadedImagesPathForArtist;

            if (!artistFromRepo.ArtistPhoto.Any(a => a.IsMain))
            {
                photo.IsMain = true;
            }

            // TODO
            if (photo.PhotoDescription == null)
            {
                photo.PhotoDescription = file.FileName;
            }

            artistFromRepo.ArtistPhoto.Add(photo);

            if (await _repo.SaveAll())
            {
                // return Ok();

                var photoToReturn = _mapper.Map<PhotoforReturnDto>(photo);
                return CreatedAtRoute("GetPhoto",
                    new { artistId = artistId, id = photo.ArtistId },
                    photoToReturn);
            }

            return BadRequest("Could not add the photo");
        }
    }
}