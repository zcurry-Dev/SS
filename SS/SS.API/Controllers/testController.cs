//
using System;
using System.Linq;
//
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//
//

namespace SS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class testController : ControllerBase
    {
    }
}