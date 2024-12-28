using BDUgram.BL.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListItem>> GetAllAsync();
        Task<int> CreateAsync(CategoryCreateDTO dto);
    }
}
