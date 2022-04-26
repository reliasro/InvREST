﻿using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Infra.Persistence.Database;

namespace Soinsoft.Inventory.Infra.Persistence;
public class Repository<T> : IRepository<T> where T:class
{
    private readonly DbContextInventory _context;
    public Repository(DbContextInventory context){
          _context = context;
    } 

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task Delete(int id)
    {
         var item =await _context.Set<T>().FindAsync(id);
         if (item==null) await Task.FromResult(-1);
         else _context.Remove(item);
    }

    public async Task<T> Get(int id)
    {
         var item= await _context.Set<T>().FindAsync(id);
         if (item==null) await Task.FromResult(-1);
         return item;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var result= _context.Set<T>().AsEnumerable(); 
        return await Task.FromResult(result);
    }

    public async Task<int> SaveChanges()
    {
       return await _context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
         return Task.FromResult(_context.Set<T>().Attach(entity));
    }

}
