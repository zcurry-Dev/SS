using Microsoft.AspNetCore.Mvc;
using SS.API.DAL;
using SS.API.EFModels;
using System.Collections.Generic;

namespace SS.API.Controllers
{
    public class ArtistController : Controller
    {
        ArtistDataAccessLayer objArtist = new ArtistDataAccessLayer();

        [HttpGet]
        [Route("api/Artist/Index")]
        public IEnumerable<Artists> Index()
        {
            return objArtist.GetAllArtists();
        }

        [HttpPost]
        [Route("api/Artist/Create")]
        public int Create([FromBody] Artists artist)
        {
            return objArtist.AddArtist(artist);
        }

        [HttpGet]
        [Route("api/Artist/Details/{id}")]
        public Artists Details(int id)
        {
            return objArtist.GetArtistData(id);
        }

        [HttpPut]
        [Route("api/Artist/Edit")]
        public int Edit([FromBody]Artists artist)
        {
            return objArtist.UpdateArtist(artist);
        }

        [HttpDelete]
        [Route("api/Artist/Delete/{id}")]
        public int Delete(int id)
        {
            return objArtist.DeleteArtist(id);
        }
    }
}
