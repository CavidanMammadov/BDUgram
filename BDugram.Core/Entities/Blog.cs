using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDugram.Core.Entities
{
    public  class Blog :BaseEntity
    {
        public string  Title     { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public User Publisher { get; set; }
        public int PublisherId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
