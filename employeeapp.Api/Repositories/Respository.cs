
using employeeapp.api.Interfaces;

public abstract  class Repository<K, T> : IRepository<K, T>
{
    protected static List<T> items = new List<T>();
    public async Task<IEnumerable<T>> GetAll()
    {
        return items;
    }


    public abstract Task<T> GetByKey(K key);

    public async Task<T> Add(T item)
    {
        items.Add(item);
        return item;
    }

    public async Task<T> Delete(K key)
    {
        var item = await GetByKey(key);
        if (item != null)
        {
            items.Remove(item);
            return item;
        }
        throw new Exception("Unable to delete");
    }


    

    public async Task<T> Update(K key, T item)
    {
        var listItem = await GetByKey(key);
        if (item != null)
        {
            items.Remove(listItem);
            items.Add(item);
            return item;
        }
        throw new Exception("Unable to update");
    }
}