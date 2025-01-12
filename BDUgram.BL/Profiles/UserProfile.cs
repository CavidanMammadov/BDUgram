using AutoMapper;
using BDugram.Core.Entities;
using BDUgram.BL.DTOs.UserDTOs;
using BDUgram.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDTO, User>()
                .ForMember(x => x.PasswordHash, x => x.MapFrom(y => HashHelper.HashPassword(y.Password)));
            CreateMap<User, UserNestedGetDto>();
        }
    }
}
