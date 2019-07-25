using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.API.DAL;
using SS.API.EFModels.Tables;

namespace SS.API.Controllers
{
    public class ArtistController
    {
        public class EmployeeController : Controller
        {
            ArtistDataAccessLayer objemployee = new ArtistDataAccessLayer();

            [HttpGet]
            [Route("api/Employee/Index")]
            public IEnumerable<Artists> Index()
            {
                return objemployee.GetAllArtists();
            }

            [HttpPost]
            [Route("api/Employee/Create")]
            public int Create([FromBody] Artists employee)
            {
                return objemployee.AddArtist(employee);
            }

            [HttpGet]
            [Route("api/Employee/Details/{id}")]
            public Artists Details(int id)
            {
                return objemployee.GetArtistData(id);
            }

            [HttpPut]
            [Route("api/Employee/Edit")]
            public int Edit([FromBody]Artists employee)
            {
                return objemployee.UpdateEmployee(employee);
            }

            [HttpDelete]
            [Route("api/Employee/Delete/{id}")]
            public int Delete(int id)
            {
                return objemployee.DeleteArtist(id);
            }
        }
    }
}