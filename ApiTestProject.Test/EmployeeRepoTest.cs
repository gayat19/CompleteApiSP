using employeeapp.Api;
using Microsoft.EntityFrameworkCore;
using employeeapp.api.Interfaces;

namespace ApiTestProject.Test;

public class EmployeeRepoTest
{
    HrContext _context;
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<HrContext>()
                     .UseInMemoryDatabase("TestDb")
                    .Options;
        _context = new HrContext(options);
    }

    [Test]
    [TestCase(101,1)]
    [TestCase(102,2)]
    [TestCase(103,3)]
    public async Task AddEmployeeTest(int did,int eid)
    {
        //Arrange
        IRepository<int, Employee> employeeRepsitory = new EmployeeRepsitoryDb(_context);
        Employee employee = new Employee
        {
            Name = "Test emp",
            Phone = "9988776655",
            DepartmentId = did
        };

        //Action
        var result = await employeeRepsitory.Add(employee);
        Console.WriteLine(result.Name);
        //Assert
        Assert.That(result.Id, Is.EqualTo(eid));
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
    
}
