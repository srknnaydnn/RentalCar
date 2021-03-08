using Core.Entities;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<UserForLoginDto>
    {
        public UserValidator()
        {

            RuleFor(p => p.Email).NotEmpty().WithMessage("email alanı boş geçilemez");
            RuleFor(p => p.Password).NotEmpty().WithMessage("şifre alanı boş geçilemez");
            RuleFor(p => p.Password).NotEmpty().WithMessage("email alanı boş geçilemez");
            RuleFor(p => p.Email).EmailAddress().WithMessage("geçersiz email");
            
        }
    }
}
