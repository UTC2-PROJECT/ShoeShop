using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models.Validations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Số điện thoại không được trống");
            RuleFor(x => x.PhoneNumber).Matches("^[0-9]*$").WithMessage("Số điện thoại phải toàn số");
            RuleFor(x => x.PhoneNumber).MaximumLength(11).WithMessage("Số điện thoại không được lớn hơn 11 số");
            RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage("Số điện thoại không được bé hơn 10 số");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Địa chỉ không được trống");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Order>.CreateWithOptions((Order)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
