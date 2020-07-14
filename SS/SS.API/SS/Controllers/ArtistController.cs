using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business;
using SS.Business.Enums;
using SS.Business.Helpers;
using SS.Business.Interfaces;
using SS.Business.Models.Artist;
using SS.Business.Pagination;

namespace SS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ServiceFilter(typeof(LogUserActivity))]
    public class ArtistController : ControllerBase
    {
        private readonly IArtist _artist;

        public ArtistController(IArtist artist)
        {
            _artist = artist;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ArtistToCreateDto artistToCreate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artist = await _artist.CreateArtistAsync(artistToCreate);

            if (artist.Id != 0)
            {
                return CreatedAtRoute(
                    artist.Id,
                    artist);
            }

            return BadRequest("Could not add artist");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var artist = await _artist.GetArtistAsync(id);

            return Ok(artist);
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List([FromQuery] ArtistPageParams artistParams)
        {
            var artists = await _artist.GetArtistsAsync(artistParams);
            Response.AddPagination(artists.CurrentPage, artists.ItemsPerPage,
                artists.TotalItems, artists.TotalPages);

            return Ok(artists);
        }

        [HttpPatch]
        [Route("Save/{id}")]
        public async Task<IActionResult> Save(int id, ArtistForUpdateDto artistForUpdateDto)
        {
            var result = await _artist.UpdateArtistAsync(id, artistForUpdateDto);

            if (result == Result.Pass)
            {
                return Ok("Artist updates have been saved");
            }

            if (result == Result.NoChange)
            {
                return Ok("No changes have been saved");
            }

            if (result == Result.Fail)
            {
                return BadRequest("Error updating the artist");
            }

            throw new Exception($"Updating artist {id} failed on save");
        }
    }
}