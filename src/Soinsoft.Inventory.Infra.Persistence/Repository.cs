using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Infra.Persistence.Database;

namespace Soinsoft.Inventory.Infra.Persistence;
public class Repository<T> : IRepository<T> where T:class
{
    private T _entity;
    private readonly DbContextInventory _context;
    public Repository(DbContextInventory context){
          _context = context;
    } 

    public async Task Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        _entity=entity;
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
        var result= _context.Set<T>().ToList(); 
        return await Task.FromResult(result);
    }

    public async Task<int> SaveChanges()
    {
       var id= await _context.SaveChangesAsync();
       return id;
    }

    public Task Update(T entity)
    {
        _entity=entity;
        return Task.FromResult(_context.Set<T>().Attach(entity));
    }

}
