using AutoMapper;

public class HRAutoMapper :Profile
{
    public HRAutoMapper()
    {
        CreateMap<AddEmployeeRequestDto, Employee>();
        CreateMap<Employee, AddEmployeeRequestDto>();
        CreateMap<AddEmployeeResponseDto, Employee>();
        CreateMap<Employee, AddEmployeeResponseDto>();
        CreateMap<Employee, GetEmployeeResponseDto>();
        CreateMap<GetEmployeeResponseDto, Employee>();
    }
}