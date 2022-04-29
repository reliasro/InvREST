using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class AddProductValidator: AbstractValidator<AddProductCmd>
    {
        public AddProductValidator(){
             RuleFor(x=>x.Description).NotEmpty().WithMessage("Please provide a description. Thanks.");
             RuleFor(x=>x.Maximun).LessThanOrEqualTo(100).WithMessage("Please provide a  max value bellow 100. Thanks.");
             RuleFor(x=>x.Minimum).GreaterThanOrEqualTo(6).WithMessage("Please provide a min value above 5. Thanks.");
        }

    }
}