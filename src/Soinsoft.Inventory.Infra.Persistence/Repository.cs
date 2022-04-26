using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Infra.Persistence.Database;

namespace Soinsoft.Inventory.Infra.Persistence;
public class Repository<T> : IRepository<T>
{
    private readonly DbContextInventory _context;
    public Repository(DbContextInventory context){
            _context = context;
    } 

    public async Task Create(T entity)
    {
         await Task.FromCanceled(new CancellationToken());
    }

    public async Task  Delete(int id)
    {
         await Task.FromCanceled(new CancellationToken());
    }

    public async Task<T> Get(int id)
    {
        throw new NotImplementedException();
       //await Task<T>.FromCanceled(new CancellationToken());
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
        //await Task.FromCanceled(new CancellationToken());
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }

    public async Task Update(T entity)
    {
         await Task.FromCanceled(new CancellationToken());
    }

}
