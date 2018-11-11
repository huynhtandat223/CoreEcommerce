using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RCommerce.Module.Authentication.Helpers;
using RCommerce.Module.Authentication.Services;
using RCommerce.Module.Authentication.ViewModels;
using RCommerce.Module.Core.Dtos;
using RCommerce.Module.Customers.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RCommerce.Module.Authentication.Controllers
{
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        public AccountsController(SignInManager<User> signInManager, UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = new User {
                UserName = userDto.UserName
            };
            var result = await _userManager.CreateAsync(appUser, userDto.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserDto userDto)
        {
            
            var loginResult = await _signInManager.PasswordSignInAsync(userDto.UserName, userDto.Password, userDto.IsRememberMe, lockoutOnFailure: false);
            if (loginResult.Succeeded)
            {
                var token = _userService.GetToken(userDto.UserName);
                var result = new { userDto.UserName, Token = token };
                return Ok(result);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return new BadRequestObjectResult(ModelState);
        }
        
    }
}
