using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.DTOs.CommonDtos
{
    public class JwtDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string  FullName { get; set; }
    }
}
