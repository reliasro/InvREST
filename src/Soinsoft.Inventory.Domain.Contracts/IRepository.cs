using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soinsoft.Inventory.Domain.Contracts
{
    public interface IRepository <T> where T: class
    {
     
       Task<IEnumerable<T>> GetAll(); 
       Task<T> Get(int id);
       Task Delete(int id);
       Task Update(T entity);
       Task Create(T entity);
       Task<int> SaveChanges();

    }
}