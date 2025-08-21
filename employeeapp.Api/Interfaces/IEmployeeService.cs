public interface IEmployeeService
{
    public Task<AddEmployeeResponseDto> AddNewEmployee(AddEmployeeRequestDto employee);
    public Task<ICollection<GetEmployeeResponseDto>> GetEmployees();
}