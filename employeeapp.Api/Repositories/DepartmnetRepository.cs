
using Microsoft.EntityFrameworkCore;

public class DepartmnetRepository : RepositoryDb<int, Department>
{
    public DepartmnetRepository(HrContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<Department>> GetAll()
    {
        var departments = await _context.Departmnets.ToListAsync();
        return departments;
    }

    public async override Task<Department> GetByKey(int key)
    {
        var department = await _context.Departmnets.SingleOrDefaultAsync(d => d.DepartmentNumber == key);
        return department;
    }
}