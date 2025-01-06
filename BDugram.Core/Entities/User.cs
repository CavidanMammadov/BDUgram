using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDugram.Core.Entities
{
    public  class User: BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }
        public bool isMale { get; set; }
        public string PasswordHash { get; set; }
        public int Role { get; set; } = 2;
        public bool IsBanned { get; set; }
        public DateTime?  UnlockTime { get; set; }

    }
}
