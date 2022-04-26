using Soinsoft.Inventory.Domain.Contracts;

namespace Soinsoft.Inventory.Infra.Persistence;
public class Repository<T> : IRepository<T>
{
   /* public Repository(DbContext context){
           
    } */
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
