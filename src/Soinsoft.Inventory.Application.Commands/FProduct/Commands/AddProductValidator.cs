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
             RuleFor(x=>x.Description).NotEmpty().WithMessage("Please provide a description.");
             RuleFor(x=>x.Maximun).LessThanOrEqualTo(1000).WithMessage("Please provide a  maximun value bellow 1000.");
             RuleFor(x=>x.Minimum).GreaterThanOrEqualTo(0).WithMessage("Please provide a minimun value above 0.");
             RuleFor(x=>x.Maximun).GreaterThan(y=>y.Minimum).WithMessage("Please provide a minimum  bellow the maximun.");
             RuleFor(x=>x.Price).GreaterThan(y=>y.Cost).WithMessage("Please provide a cost  bellow the price.");
        }

    }
}