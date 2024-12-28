using BDugram.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDugram.Core.Entities
{
    public class Category:BaseEntity
    {
        public string  Name { get; set; } = null!;
        public string  Icon { get; set; }
    }
}   
