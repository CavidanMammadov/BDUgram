using BDUgram.BL.DTOs.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.ExternalSerives.Implements
{
    public interface ITokenHandler
    {
        string CreateToken( JwtDto dto);
    }
}
