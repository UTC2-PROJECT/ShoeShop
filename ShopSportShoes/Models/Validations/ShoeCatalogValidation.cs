using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models.Validations
{
    public class ShoeCatalogValidation : AbstractValidator<ShoeCatalog>
    {
        public ShoeCatalogValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Loại giày không được trống");
        }
    }
}
