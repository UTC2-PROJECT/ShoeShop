using FluentValidation;
using ShopSportShoes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên không được trống");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được trống");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email không không hợp lệ");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu không được trống");
            RuleFor(x => x.RePassword).NotEmpty().WithMessage("Mật khẩu không được trống");
            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Mật khẩu không khớp");
            RuleFor(x => x.Roles).Must(x => x.Count > 0).WithMessage("Chưa chọn quyền cho người dùng");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<User>.CreateWithOptions((User)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
