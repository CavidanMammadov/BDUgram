using AutoMapper;
using BDugram.Core.Entities;
using BDugram.Core.Enums;
using BDugram.Core.Repositories;
using BDUgram.BL.DTOs.UserDTOs;
using BDUgram.BL.Exceptions.AuthExceptions;
using BDUgram.BL.Exceptions.Common;
using BDUgram.BL.Helpers;
using BDUgram.BL.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BDUgram.BL.ExternalSerives.Implements;

namespace BDUgram.BL.Services.implements
{
    public class AuthService(IUserRepository _repo, IMapper _mapper, IMemoryCache _cache ,ITokenHandler _tokenHandler) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _repo.GetAll().Where(x => x.UserName == dto.UserNameOrEmail
            || x.Email == dto.UserNameOrEmail).FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException<User>();



            return _tokenHandler.CreateToken(new DTOs.CommonDtos.JwtDto
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                UserName = user.UserName
            });


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
            SendVerificationEmailAsync(user.Email);
        }

        public async Task<int> SendVerificationEmailAsync(string email)
        {

            if (_cache.TryGetValue<int>(email, out int _))
                throw new ExistException("Email artiq gonderilib ");
            if (!await _repo.IsExistAsync(z => z.Email == email))
                throw new NotFoundException<User>();
            Random r = new Random();
            int code = r.Next(100000, 999999);
            SmtpClient smtp = new();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("cavidanbm-bp215@code.edu.az", "lvht hxma hwuq gouq");
            smtp.EnableSsl = true;
            MailAddress from = new MailAddress("cavidanbm-bp-215@code.edu.az", "Email Verification");
            MailAddress to = new MailAddress(email);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "Verify gmail";
            msg.Body = code.ToString();
            smtp.Send(msg);
            _cache.Set(email, code, TimeSpan.FromMinutes(15));
            return code;

        }

        public async Task<bool> VerifyAccountAsync(string email, int code)
        {
            if (!_cache.TryGetValue<int>(email, out int result))
                throw new NotFoundException("Daxil etdiyiniz email yanlisdir");
            if (result != code)
                throw new CodeIsInvalidException();
            var user = await _repo.GetWhere(x => x.Email == email).FirstOrDefaultAsync();
            user!.IsVerified = true;
            user.Role = user.Role | (int)Roles.Publisher;
            await _repo.SaveAsync();
            return true;


        }
    }
}
