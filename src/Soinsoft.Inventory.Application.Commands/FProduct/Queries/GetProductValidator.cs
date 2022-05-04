using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Queries
{
    public class GetProductValidator: AbstractValidator<GetProductQry>
    {
        public GetProductValidator(){
             RuleFor(x=>x.Id).NotEmpty().GreaterThan(0).WithMessage("Provide a valid product id");
        }
    }
}