using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Interfaces;
using SS.Business.Models.Artist;
using SS.Helpers;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Controllers.Artist
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ServiceFilter(typeof(LogUserActivity))]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artist;

        public ArtistController(IArtistRepository artist)
        {
            _artist = artist;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ArtistToCreateDto artistToCreate)
        {
            var artistForDetailedDto = await _artist.CreateArtist(artistToCreate);

            if (artistForDetailedDto.Id != 0)
            {
                return CreatedAtRoute(
                    artistForDetailedDto.Id,
                    artistForDetailedDto);
            }

            return BadRequest("Could not add artist");
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var artistToReturn = await _artist.GetArtistById(id);

            return Ok(artistToReturn);
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ArtistParams artistParams)
        {
            var artistList = await _artist.GetArtists(artistParams);
            Response.AddPagination(artistList.CurrentPage, artistList.PageSize,
                artistList.TotalCount, artistList.TotalPages);

            return Ok(artistList.Artists);
        }

        [HttpPatch]
        [Route("Save/{id}")]
        public async Task<IActionResult> Save(int id, ArtistForUpdateDto artistForUpdateDto)
        {
            var result = await _artist.UpdateArtist(id, artistForUpdateDto);

            if (result)
            {
                return NoContent();
            }

            throw new Exception($"Updating artist {id} failed on save");
        }
    }
}