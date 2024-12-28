using BDugram.Core.Entities;
using BDugram.Core.Repositories;
using BDUgram.BL.DTOs.CategoryDTOs;
using BDUgram.BL.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.implements
{
    public class CategoryService(ICategoryRepository _repo) : ICategoryService
    {
        public async Task<int> CreateAsync(CategoryCreateDTO dto)
        {
            Category cat = dto;
            await _repo.AddAsync(cat);
            await _repo.SaveAsync();
            return cat.Id;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllAsync()
        {
            return await _repo.GetAll().Select(x => new CategoryListItem
            {
                Id = x.Id,
                Name = x.Name,
                Icon = x.Icon
            }).ToListAsync();
        }
    }
}
