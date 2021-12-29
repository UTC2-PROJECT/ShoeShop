using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models.Validations
{
    public class ShoeValidation : AbstractValidator<Shoe>
    {
        public ShoeValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Tiêu đề bị trống");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Mô tả bị trống");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Số tiền phải lớn hơn 0");
            RuleFor(x => x.ShoeCatalogNavigation).NotEmpty().WithMessage("Loại giày không được trống");

        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Shoe>.CreateWithOptions((Shoe)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
