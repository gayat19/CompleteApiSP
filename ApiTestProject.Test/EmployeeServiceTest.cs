using employeeapp.Api;
using Microsoft.EntityFrameworkCore;
using employeeapp.api.Interfaces;
using AutoMapper;
using Moq;
using Microsoft.Extensions.Logging;


namespace ApiTestProject.Test;

public class EmployeeServiceTest
{
    HrContext _context;
    IRepository<int, Employee> employeeRepsitory;
    IRepository<int, Department> departmnetRepository;
    IRepository<int, User> userRepository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<HrContext>()
                     .UseInMemoryDatabase("TestDb")
                    .Options;
        _context = new HrContext(options);
        employeeRepsitory = new EmployeeRepsitoryDb(_context);
        departmnetRepository = new DepartmnetRepository(_context);
        userRepository = new UserRepository(_context);
    }

    // [Test]
    // [TestCase(101,1)]
    // [TestCase(102,2)]
    // [TestCase(103,3)]
    // public async Task AddEmployeeTest(int did,int eid)
    // {
    //     //Arrange
    //     await departmnetRepository.Add(new Department() {DepartmentNumber=did, Name = "Test" });
    //     AddEmployeeRequestDto requestObj = new AddEmployeeRequestDto
    //     {
    //         Name = "Test emp",
    //         Phone = "9988776655",
    //         DepartmentId = did
    //     };
    //     Employee employee = new Employee
    //     {
    //         Name = "Test emp",
    //         Phone = "9988776655",
    //         DepartmentId = did
    //     };
    //     AddEmployeeResponseDto responseObject = new AddEmployeeResponseDto
    //     {
    //         Id=eid,
    //         Name = "Test emp",
    //         Phone = "9988776655",
    //         DepartmnetName ="Test"
    //     };
    //     Mock<IMapper> mapper = new Mock<IMapper>();
    //     mapper.Setup(m => m.Map<Employee>(It.IsAny<AddEmployeeRequestDto>())).Returns(employee);
    //     mapper.Setup(m => m.Map<AddEmployeeResponseDto>(It.IsAny<Employee>())).Returns(responseObject);
    //     IEmployeeService employeeService = new EmployeeService(employeeRepsitory,departmnetRepository,userRepository,mapper.Object);

    //     //Action
    //     var result = await employeeService.AddNewEmployee(requestObj);
    //     //Console.WriteLine(result.Id);
    //     //Assert
    //     //Assert.That(result.Id, Is.EqualTo(eid));
    // }

    [Test]
    [TestCase(101, 1)]
    public async Task AddEmployeeExceptionTest(int did, int eid)
    {
        //Arrange
        AddEmployeeRequestDto requestObj = new AddEmployeeRequestDto
        {
            Name = "Test emp",
            Phone = "9988776655",
            DepartmentId = did
        };
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock< ILogger<EmployeeService>> logger = new Mock< ILogger<EmployeeService>>();
        IEmployeeService employeeService = new EmployeeService(employeeRepsitory, departmnetRepository, userRepository, mapper.Object, logger.Object);
        //Assert
        Assert.ThrowsAsync<Exception>(async () => await employeeService.AddNewEmployee(requestObj));
    }


    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

}
