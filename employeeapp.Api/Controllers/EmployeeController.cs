using employeeapp.api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<GetEmployeeResponseDto>>> GetEmployees()
    {
        try
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }
        catch (System.Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]

    [ProducesResponseType(typeof(AddEmployeeResponseDto),StatusCodes.Status201Created)]
    [ProducesErrorResponseType(typeof(ErrorObject))]
    [Authorize(Roles = "HR")]
    [CustomExceptionFilter]
    public async Task<ActionResult<AddEmployeeResponseDto>> Anymethod([FromBody] AddEmployeeRequestDto employee)
    {
        // try
        // {
        var result = await _employeeService.AddNewEmployee(employee);
        return Created("", result);
        // }
        // catch (System.Exception e)
        // {
        //     return BadRequest(e.Message);
        // }
    }

}