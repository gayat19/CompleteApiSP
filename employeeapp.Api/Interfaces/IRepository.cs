using System.Collections.Generic;

namespace employeeapp.api.Interfaces;
public interface IRepository<K, T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetByKey(K key);

    public Task<T> Add(T item);
    public Task<T> Delete(K key);
    public Task<T> Update(K key, T item);
}
