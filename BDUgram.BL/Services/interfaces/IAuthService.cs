using BDUgram.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto dto);
        Task RegisterAsync(RegisterDTO dto);
        Task<int> SendVerificationEmailAsync(string email);
    }
}
