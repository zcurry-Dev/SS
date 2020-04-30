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
            var artistList = await _artist.GetArtists(artistParams);
            Response.AddPagination(artistList.CurrentPage, artistList.PageSize,
                artistList.TotalCount, artistList.TotalPages);

            return Ok(artistList.Artists);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtist(int artistId)
        {
            var artistToReturn = await _artist.GetArtistById(artistId);

            return Ok(artistToReturn);
        }

        [HttpGet]
        [Route("GetArtistPhoto/{id}")]
        public async Task<IActionResult> GetArtistPhoto(int id)
        {
            var artistPhoto = await _artist.GetArtistPhotoByPhotoId(id);

            return File(artistPhoto.File, artistPhoto.PhotoFileContentType, artistPhoto.PhotoFileName);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistForUpdateDto artistForUpdateDto)
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