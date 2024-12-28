using BDugram.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public static implicit operator Category(CategoryCreateDTO dto)
        {
            Category category = new Category
            {
                Icon = dto.Icon,
                Name = dto.Name

            };
            return category;
        }
    }
}
