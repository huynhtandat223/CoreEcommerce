using Microsoft.IdentityModel.Tokens;
using RCommerce.Module.Core.Dtos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RCommerce.Module.Authentication.Helpers
{
    public static class Tokens
    {
        public static string BuildToken(UserDto user, string issuer, string issuerKey)
        {
            //claimns là nội dung ở phần payload, bạn có thể set các thông tin của người dùng tại đây
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddMinutes(30), //expire time là 30 phút
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
