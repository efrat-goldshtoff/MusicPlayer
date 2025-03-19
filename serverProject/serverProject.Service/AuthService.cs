using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using serverProject.Core.Repositories;
using Microsoft.IdentityModel.Tokens;
using serverProject.Core.models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace serverProject.Service
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public AuthService(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        public string GenerateJwtToken(string name, string password)
        {
            if (name == "" && password == "")
                return GenerateToken(name, new[] { "Admin" });
            var user = _userRepository.GetUserByCredentials(name, password);
            if (user != null)
                return GenerateToken(name, new[] { "User" });
            return GenerateToken(name, new[] { "Viewer" });
        }

        private string GenerateToken(string name, string[] roles)
        {
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
