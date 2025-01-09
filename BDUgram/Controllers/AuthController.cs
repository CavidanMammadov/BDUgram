using BDUgram.BL.DTOs.UserDTOs;
using BDUgram.BL.Services.implements;
using BDUgram.BL.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDUgram.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService _service , IEmailService emailService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register (RegisterDTO dto)
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
            emailService.EmailConfirmation(user, name);
            return Ok();
        }
    }
}
