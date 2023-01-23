﻿using Ecommerce.Shared.Dtos;
using ECommerce.IdentityServer.DTOs;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace ECommerce.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                City = signUpDto.City,

            };

            var result= await _userManager.CreateAsync(user,signUpDto.Password);
            if(!result.Succeeded)
            {
                return BadRequest(ResponseDto<NoContent>.Fail(result.Errors.Select(x=> x.Description).ToList(),400));
               
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub); //sub kullanıcı idsini tutuyor.

            var user = await _userManager.FindByIdAsync(userId.Value);

            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                City = user.City
            });
        }
    }
}
