using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.API.Data;
using SS.API.Data.Interfaces;
using SS.API.Dtos;
using SS.API.Dtos.User;

namespace SS.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _repo.GetUser(userId);
            var userToReturn = _mapper.Map<UserforDetailDto>(user);

            return Ok(userToReturn);
        }
    }
}