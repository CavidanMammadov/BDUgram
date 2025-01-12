using AutoMapper;
using BDugram.Core.Entities;
using BDugram.Core.Enums;
using BDugram.Core.Repositories;
using BDUgram.BL.DTOs.BlogsDto;
using BDUgram.BL.DTOs.CategoryDTOs;
using BDUgram.BL.Exceptions;
using BDUgram.BL.Exceptions.Common;
using BDUgram.BL.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Services.implements
{
    public class BlogService(IBlogRepository _repo, ICategoryRepository _categoryRepo ,IMapper _mapper) : IBlogService
    {
        public async Task<int> CreateAsync(BlogCreateDto dto)
        {
            if (!await _categoryRepo.IsExistAsync(dto.CategoryId))
                throw new NotFoundException<Category>();

            var user = await _repo.GetCurrentUserAsync();
            if (user is null)
                throw new UserIsNotLoggedException<User>();

            int role = (int)Roles.Publisher;
            if ((user.Role & role) != role)
                throw new UserPermissionException();
                
                
            var blog = _mapper.Map<Blog>(dto);
            blog.Publisher = user; 
            await _repo.AddAsync(blog);
            await _repo.SaveAsync();
            return blog.Id;
        }

        public  async Task<List<BlogGetDto>> GetAllAsync()
        {
            var blogs = await _repo.GetAll("Category", "Publisher").ToListAsync();
            return _mapper.Map<List<BlogGetDto>>( blogs);
        }
    }
}
