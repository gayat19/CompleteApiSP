
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FirstController : ControllerBase
{

    [HttpGet]
    public string GetExample()
    {
        return "Hello World";
    }

    
}