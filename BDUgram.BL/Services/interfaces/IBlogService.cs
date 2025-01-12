using BDugram.Core.Entities;
using BDUgram.BL.DTOs.BlogsDto;
using BDUgram.BL.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.interfaces
{
    public interface IBlogService
    {
        Task<int> CreateAsync ( BlogCreateDto dto );
        Task<List<BlogGetDto>> GetAllAsync (   );

    }
}
