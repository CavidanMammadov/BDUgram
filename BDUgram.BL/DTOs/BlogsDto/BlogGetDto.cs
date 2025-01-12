using BDUgram.BL.DTOs.CategoryDTOs;
using BDUgram.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.DTOs.BlogsDto
{
    public class BlogGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedTime { get; set; }
        public UserNestedGetDto  Publisher { get; set; }
        public CategoryNestedGetDto  Category { get; set; }

    }
}
