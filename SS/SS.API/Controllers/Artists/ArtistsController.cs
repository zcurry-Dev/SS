using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SS.API.Data.Interfaces;
using SS.API.Dtos.Artist;
using SS.API.Helpers;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Controllers.Artists
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistDataRepository _repo;
        private readonly IMapper _mapper;
        public ArtistsController(IArtistDataRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists([FromQuery] ArtistParams artistParams)
        {
            var artists = await _repo.GetArtists(artistParams);
            var artistsToReturn = _mapper.Map<IEnumerable<ArtistForListDto>>(artists);
            Response.AddPagination(artists.CurrentPage, artists.PageSize,
                artists.TotalCount, artists.TotalPages);

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
        [Route("GetArtistPhoto/{id}")]
        public async Task<IActionResult> GetArtistPhoto(int id)
        {
            var artistPhoto = await _repo.GetArtistPhoto(id);
            var file = await _repo.GetPhotoFile(id);

            return File(file, artistPhoto.PhotoFileContentType, artistPhoto.PhotoFileName);
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