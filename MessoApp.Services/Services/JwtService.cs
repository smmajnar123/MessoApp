using MessoApp.DTO.ResponseModels;
using MessoApp.Services.IServices;
using MessoApp.Shared.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Services.Services
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
        private readonly IConfiguration _config = configuration;

        public LoginResponseModel LoginToken(int id, string mobile, Role role)
        {
            var tokenString = CreateToken(id, mobile, role);
            if(string.IsNullOrEmpty(tokenString))
            {
                return null!;
            }
            else
            {
                return new LoginResponseModel
                {
                    Token = tokenString
                };
            }
        }

        private string CreateToken(int id, string mobile, Role role)
        {
            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.MobilePhone, mobile),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
