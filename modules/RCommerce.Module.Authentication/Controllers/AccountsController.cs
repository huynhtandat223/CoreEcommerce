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
        private readonly ITokenService _tokenService;

        public AccountsController(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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
                var user = _userManager.Users.Single(i => i.UserName == userDto.UserName);
                var claims = await BuildClaims(user);
                var token = _tokenService.GenerateAccessToken(claims);
                
                var result = new { userDto.UserName, Token = token };
                return Ok(result);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return new BadRequestObjectResult(ModelState);
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("/api/token/refresh")]
        public async Task<IActionResult> RefeshToken(RefreshTokenModel model)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(model.Token);
            if (principal == null)
            {
                return BadRequest(new { Error = "Invalid token" });
            }

            var user = await _userManager.GetUserAsync(principal);
            var verifyRefreshTokenResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.RefreshTokenHash, model.RefreshToken);
            if (verifyRefreshTokenResult == PasswordVerificationResult.Success)
            {
                var claims = await BuildClaims(user);
                var newToken = _tokenService.GenerateAccessToken(claims);
                return Ok(new { token = newToken });
            }

            return Forbid();
        }

        private async Task<IList<Claim>> BuildClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return claims;
        }
    }
}
