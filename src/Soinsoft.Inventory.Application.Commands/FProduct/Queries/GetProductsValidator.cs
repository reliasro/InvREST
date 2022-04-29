using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Queries
{
    public class GetProductsValidator: AbstractValidator<GetProductsQry>
    {
        public GetProductsValidator(){
            RuleFor(x=>x.Id==1);
        }
    }
}