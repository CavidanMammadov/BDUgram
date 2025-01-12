using AutoMapper;
using BDugram.Core.Entities;
using BDUgram.BL.DTOs.BlogsDto;
using BDUgram.BL.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Profiles
{
    public class BlogProfile :Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogGetDto>();
            CreateMap<BlogCreateDto, Blog>();
        }
    }
}
