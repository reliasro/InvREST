using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;
using Soinsoft.Inventory.Application.Contracts.DTOs;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.Mappings
{
    public class Profiles: Profile
    {
        public Profiles(){
            
            CreateMap<Product, ProductDTO>();
            CreateMap<AddProductCmd, Product>();
            CreateMap<EditProductCmd, Product>();
        }
    }
}