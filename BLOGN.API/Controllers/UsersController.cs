﻿using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Services.IServices;
using BLOGN.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOGN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        public IActionResult Authenticate(UserDto userDto)
        {
            var user =  _userServices.Authenticate(userDto.UserName, userDto.Password);
            if (user ==null)
            {
                return BadRequest(new { message = "Kullanıcı Adı veya Parola Hatalı" });
            }
            return Ok(user);
        }
    }
}
