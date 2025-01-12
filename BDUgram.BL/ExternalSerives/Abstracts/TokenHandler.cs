using BDugram.Core.Entities;
using BDUgram.BL.DTOs.CommonDtos;
using BDUgram.BL.ExternalSerives.Implements;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.ExternalSerives.Abstracts
{
    public class TokenHandler(IConfiguration _config) : ITokenHandler
    {
        public string CreateToken(JwtDto dto)
        {
            string issuer = _config["Jwt:Issuer"]!;
            string audience = _config["Jwt:Audience"]!;
            string secretKey = _config["Jwt:SecretKey"]!;
            List<Claim> claims = [
               new Claim  (ClaimTypes.Name , dto.UserName),
                new Claim( ClaimTypes.Email , dto.Email),
                new Claim(ClaimTypes.Role , dto.Role.ToString()),
                new Claim ("Fullname", dto.FullName)
               ];
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSec = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(36),
                signingCredentials: cred

                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSec);
        }
    }
}
