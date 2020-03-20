using Microsoft.AspNetCore.Mvc;
using SS.API.DAL;
using SS.API.EFModels;
using System.Collections.Generic;

namespace SS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistsController : ControllerBase
	{
		ArtistDataAccessLayer objArtist = new ArtistDataAccessLayer();

		// GET api/Artist
		[HttpGet]
		public IEnumerable<Artists> Get()
		{
			return objArtist.GetAllArtists();
		}

		// GET api/Artist/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/Artist
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/Artist/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/Artist/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

	}
}
