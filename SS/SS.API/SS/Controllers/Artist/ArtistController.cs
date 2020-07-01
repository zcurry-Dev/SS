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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artist = await _artist.CreateArtist(artistToCreate);

            if (artist.Id != 0)
            {
                return CreatedAtRoute(
                    artist.Id,
                    artist);
            }

            return BadRequest("Could not add artist");
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var artist = await _artist.GetArtistById(id);

            return Ok(artist);
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ArtistParams artistParams)
        {
            var artists = await _artist.GetArtists(artistParams);
            Response.AddPagination(artists.CurrentPage, artists.PageSize,
                artists.TotalCount, artists.TotalPages);

            return Ok(artists.List);
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