using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.API.Data;
using SS.API.Dtos;

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
    }
}