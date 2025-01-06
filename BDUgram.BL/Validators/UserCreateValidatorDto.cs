using BDugram.Core.Repositories;
using BDUgram.BL.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Validators
{
    public class UserCreateValidatorDto : AbstractValidator<RegisterDTO>
    {
        //readonly IUserRepository _repo;
        //public UserCreateValidatorDto repo;
        public UserCreateValidatorDto()
        {
           // _repo = repo;
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty();
                //.Must(x=> _repo.GetUserByUserNameAsync(x).Result == null )
                //.WithMessage("UserName exist");
        }
    }
}
