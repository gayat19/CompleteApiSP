


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost]
    public async Task<ActionResult<LoginResponseDto>> LoginClearTestPass(LoginRequestDto loginuser)
    {
        try
        {
            var result = await _authenticationService.Login(loginuser);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
}