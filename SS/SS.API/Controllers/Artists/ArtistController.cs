using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.API.Business.Dtos.Artist;
using SS.API.Business.Interfaces;
using SS.API.Helpers;
using SS.API.Helpers.Pagination.PagedParams;

namespace SS.API.Controllers.Artists
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artist;
        public ArtistController(IArtistRepository artist)
        {
            _artist = artist;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists([FromQuery] ArtistParams artistParams)
        {
            var artists = await _artist.GetArtists(artistParams);
            var artistsToReturn = _artist.MapArtistsToDto(artists);
            Response.AddPagination(artists.CurrentPage, artists.PageSize,
                artists.TotalCount, artists.TotalPages);

            return Ok(artistsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int artistId)
        {
            var artistToReturn = await _artist.GetArtistById(artistId);

            return Ok(artistToReturn);
        }

        [HttpGet]
        [Route("GetArtistPhoto/{id}")]
        public async Task<IActionResult> GetArtistPhoto(int artistId)
        {
            var artistPhoto = await _artist.GetArtistPhotoByArtistId(artistId);

            return File(artistPhoto.File, artistPhoto.PhotoFileContentType, artistPhoto.PhotoFileName);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto)
        {
            var result = await _artist.UpdateArtist(artistId, artistForUpdateDto);

            if (result)
            {
                return NoContent();
            }

            throw new Exception($"Updating user {artistId} failed on save");
        }
    }
}