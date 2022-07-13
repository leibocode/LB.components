using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Appliation.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public string OpenId { get; set; }
    }

    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("名称不能为空");
            RuleFor(x => x.OpenId).NotEmpty().WithMessage("openId不能为空");
        }
    }
}
