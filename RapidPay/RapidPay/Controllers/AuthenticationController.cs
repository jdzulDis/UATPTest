using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidPay.DTOS;
using RapidPay.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly AplicationDbContext _context;
        public AuthenticationController(AplicationDbContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;

        }
        [HttpPost("login")]
        //for generating the token
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                       .SingleOrDefaultAsync(x => x.Name == loginDto.Name && x.Password == loginDto.Password);


            if (user != null)
            {

                return new UserDto
                {
                    Name = user.Name,
                    Password = user.Password,
                    Token = _tokenService.CreateToken(user)
                };
            }
            else
            {
                return Unauthorized("Invalid username");
            }

        }



    }
}
