using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soinsoft.Inventory.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Infra.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Soinsoft.Inventory.Infra.Persistence.Container
{
    public static class PersistenceServices
    {
        public static IServiceCollection  PersistenceRegister(this IServiceCollection services, IConfiguration config){
            //Registro el servicio del patron generico:
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            //Registro el DatabaseContext con su tipo y connectionstring
            services.AddDbContext<DbContextInventory>(opt=>opt.UseSqlite(config.GetConnectionString("SQLiteDatabase")));
            return services;

        }
    }
}