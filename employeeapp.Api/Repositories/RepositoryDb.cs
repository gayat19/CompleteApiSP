
using employeeapp.api.Interfaces;

public abstract  class RepositoryDb<K, T> : IRepository<K, T>
{
    protected readonly HrContext _context;

    public RepositoryDb(HrContext context)
    {
        _context = context;
    }
    public abstract Task<IEnumerable<T>> GetAll();


    public abstract Task<T> GetByKey(K key);

    public async Task<T> Add(T item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<T> Delete(K key)
    {
        var item = await GetByKey(key);
        if (item != null)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
        throw new Exception("Unable to delete");
    }

    public async Task<T> Update(K key, T item)
    {
        var listItem = await GetByKey(key);
        if (item != null)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        throw new Exception("Unable to update");
    }
}