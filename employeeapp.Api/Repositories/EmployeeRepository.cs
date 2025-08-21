
public class EmployeeRepsitory : Repository<int, Employee>
{
    
    public override async Task<Employee> GetByKey(int key)
    {
        var employee = items.SingleOrDefault(e => e.Id == key);
        return employee;
    }
}