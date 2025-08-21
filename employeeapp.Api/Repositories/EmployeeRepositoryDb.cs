

using Microsoft.EntityFrameworkCore;

public class EmployeeRepsitoryDb : RepositoryDb<int, Employee>
    {
        public EmployeeRepsitoryDb(HrContext context) : base(context)
        {

        }

    public override async Task<IEnumerable<Employee>> GetAll()
    {
        var emploees = await _context.Employees.ToListAsync();
        return emploees;
    }

        public override async Task<Employee> GetByKey(int key)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == key);
            return employee;
        }
    }
