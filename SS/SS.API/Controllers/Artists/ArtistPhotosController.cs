using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SS.API.Data;
using SS.API.Dtos;
using SS.API.Models;

namespace SS.API.Controllers
{
    [Authorize]
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

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
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
                    "GetPhoto",
                    new { artistId = artistId, id = photo.ArtistPhotoId },
                    photoToReturn);
            }

            return BadRequest("Could not add the photo");
        }
    }
}