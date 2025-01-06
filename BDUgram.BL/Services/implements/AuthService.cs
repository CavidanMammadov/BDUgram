using AutoMapper;
using BDugram.Core.Entities;
using BDugram.Core.Repositories;
using BDUgram.BL.DTOs.UserDTOs;
using BDUgram.BL.Exceptions.Common;
using BDUgram.BL.Helpers;
using BDUgram.BL.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.implements
{
    public class AuthService(IUserRepository _repo, IMapper _mapper) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _repo.GetAll().Where(x => x.UserName == dto.UserNameOrEmail
            || x.Email == dto.UserNameOrEmail).FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException<User>();

            List<Claim> claims = [
                new Claim  (ClaimTypes.Name , user.UserName),
                new Claim( ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Role , user.Role.ToString()),
                new Claim ("Fullname", user.FullName)
                ];
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("46e52cf4-5a0f-4091-bf23-95dfde630a43"));
            SigningCredentials cred = new SigningCredentials ( key , SecurityAlgorithms.HmacSha256)
            JwtSecurityToken jwtSec = new JwtSecurityToken(
                issuer: "https://localhost:7087",
                audience: "https://localhost:7087",
                claims : claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(36),
                signingCredentials : cred

                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            return handler.WriteToken(jwtSec);


        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            var user = await _repo.GetAll().Where(x => x.UserName == dto.UserName
            || x.Email == dto.Email).FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.Email == dto.Email)
                {
                    throw new ExistException("Email already used");
                }
                else
                {
                    throw new ExistException("Username already token");
                }
            }
            user = _mapper.Map<User>(dto);
            await _repo.AddAsync(user);
            await _repo.SaveAsync();
        }
    }
}
