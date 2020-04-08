using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SS.API.Data;
using SS.API.Dtos;
using static System.Net.Mime.MediaTypeNames;

namespace SS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _repo;
        private readonly IMapper _mapper;
        public ArtistsController(IArtistRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await _repo.GetArtists();
            var artistsToReturn = _mapper.Map<IEnumerable<ArtistForListDto>>(artists);

            return Ok(artistsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await _repo.GetArtist(id);
            var artistToReturn = _mapper.Map<ArtistForDetailedDto>(artist);

            return Ok(artistToReturn);
        }

        [HttpGet]
        [Route("GetArtistPhoto")]
        public async Task<IActionResult> GetArtistPhoto(ArtistPhotoForReturnDto artistPhotoForReturnDto)
        {
            var artistPhoto = await _repo.GetArtistPhoto(artistPhotoForReturnDto.ArtistId, artistPhotoForReturnDto.PhotoId);
            var file = await _repo.GetPhoto(artistPhoto);

            var fileType = "jpeg";
            var fileName = "fileName.jpg";

            return File(file, "image/" + fileType, fileName);
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> GetImageTest()
        {
            string fullPath = @"X:/uploadedImages/artists/1/myArcher.jpg";
            var b = await System.IO.File.ReadAllBytesAsync(fullPath);
            return File(b, "image/jpeg");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistForUpdateDto artistForUpdateDto)
        {
            // if updating logged in user logic, swap artist and user
            // if (id != int.Parse(Artist.FindFirst(ClaimTypes.NameIdentifier).Vale)) {
            //     return Unauthorized();
            // }

            var artistFromRepo = await _repo.GetArtist(id);

            _mapper.Map(artistForUpdateDto, artistFromRepo);

            if (await _repo.SaveAll())
            {
                return NoContent();
            }

            throw new Exception($"Updating user {id} failed on save");
        }
    }
}