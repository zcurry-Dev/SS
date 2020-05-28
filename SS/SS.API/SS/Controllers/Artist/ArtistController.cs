using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Business.Dtos.Accept;
using SS.Business.Interfaces;
using SS.Helpers;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Controllers.Artist
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artist;

        [HttpPost("create")]
        public async Task<IActionResult> CreateArtist(ArtistToCreate artistToCreate)
        {
            var artistForDetailedDto = await _artist.CreateArtist(artistToCreate);

            if (artistForDetailedDto.Id != 0)
            {
                var artistToReturn = await _artist.GetArtistById(artistForDetailedDto.Id);
                return CreatedAtRoute(
                    artistToReturn.Id,
                    artistToReturn);
            }

            return BadRequest("Could not add artist");
        }

        public ArtistController(IArtistRepository artist)
        {
            _artist = artist;
        }

        // [ServiceFilter(typeof(LogUserActivity))]
        [HttpGet]
        public async Task<IActionResult> GetArtists([FromQuery] ArtistParams artistParams)
        {
            var artistList = await _artist.GetArtists(artistParams);
            Response.AddPagination(artistList.CurrentPage, artistList.PageSize,
                artistList.TotalCount, artistList.TotalPages);

            return Ok(artistList.Artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artistToReturn = await _artist.GetArtistById(id);

            return Ok(artistToReturn);
        }

        [HttpGet]
        [Route("GetPhotoFile/{id}")]
        public async Task<IActionResult> GetPhotoFile(int id)
        {
            var artistPhoto = await _artist.GetArtistPhotoFileByPhotoId(id);

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

        //
        // Photo Methods
        //
        [HttpGet("GetArtistPhoto/{id}", Name = "GetArtistPhoto")]
        public async Task<IActionResult> GetArtistPhoto(int id)
        {
            var photo = await _artist.GetArtistPhotoByPhotoId(id);

            return Ok(photo);
        }

        [HttpPost("AddArtistPhoto/{id}")]
        public async Task<IActionResult> AddPhotoForArtist(int id,
            [FromForm] PhotoForCreationDto photoForCreationDto)
        {
            var result = await _artist.UploadPhoto(id, photoForCreationDto);

            if (result)
            {
                var photoToReturn = await _artist.GetMostRecentArtistPhoto(id);
                return CreatedAtRoute(
                    "GetArtistPhoto",
                    new { id = photoToReturn.Id },
                    photoToReturn);
            }

            return BadRequest("Could not add the photo");
        }

        [HttpPost("SetMain")]
        public async Task<IActionResult> SetMainPhoto(PhotoIds photoIds)
        {
            var artist = await _artist.GetArtistById(photoIds.ArtistId);

            if (!artist.PhotoIds.Contains(photoIds.PhotoId))
            {
                return Unauthorized();
            }

            if (artist.MainPhotoId == photoIds.PhotoId)
            {
                return BadRequest("This is already the main photo");
            }

            var result = await _artist.SetNewMainPhoto(photoIds);
            if (result)
            {
                return NoContent();
            }

            return BadRequest("Could not set photo to main");
        }

        [HttpDelete("DeletePhoto")]
        public async Task<IActionResult> DeletePhoto(PhotoIds photoIds)
        {
            var artist = await _artist.GetArtistById(photoIds.ArtistId);

            if (!artist.PhotoIds.Contains(photoIds.PhotoId))
            {
                return Unauthorized();
            }

            if (artist.MainPhotoId == photoIds.PhotoId)
            {
                return BadRequest("You cannot delete your main photo");
            }

            //
            // DELETE FILE FROM SYSTEM
            //
            //

            // if file deleted "OK"
            // if (result.Result == "ok") {} then 

            var result = await _artist.DeletePhoto(photoIds.PhotoId);
            if (result)
            {
                return Ok();
            }

            return BadRequest("Failed to delete the photo");
        }
    }
}