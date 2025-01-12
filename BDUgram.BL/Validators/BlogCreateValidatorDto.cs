using BDUgram.BL.DTOs.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDUgram.BL.Validators
{
    public class BlogCreateValidatorDto :AbstractValidator<BlogCreateDto>
    {
        public BlogCreateValidatorDto()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull();
        }

    }
}
