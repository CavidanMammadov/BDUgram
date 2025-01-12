using BDUgram.BL.DTOs.UserDTOs;
using BDUgram.BL.Services.implements;
using BDUgram.BL.Services.interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDUgram.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService _service, IEmailService emailService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _service.LoginAsync(dto));
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(string user, string name)
        {
            emailService.SendEmail(user, name);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> SendVerificationEmail(string email)
        {
            return Ok(await _service.SendVerificationEmailAsync(email));
        }
        [HttpPost]
        public async Task<IActionResult> VerifyAccount(string email, int code)
        {
            return Ok(await _service.VerifyAccountAsync(email, code));
        }
        [HttpPost]
        public async Task<IActionResult> Bitwise(int number)
        {
            int a = 32 | 16 | 8 | 4 | 2;
            return Ok((a & number) == number);


        }
    }
}
