
using System.Security.Cryptography;
using System.Text;

public class AuhenticationService : IAuthenticationService
{
    private readonly ILOginSP _loginSpService;
    private readonly ITokenService _tokenService;

    public AuhenticationService(ILOginSP loginSpService,
                                ITokenService tokenService)
    {
        _loginSpService = loginSpService;
        _tokenService = tokenService;
    }
    public async Task<LoginResponseDto> Login(LoginRequestDto loginUser)
    {
        try
        {
            var userDb = await _loginSpService.ExecuteSP(loginUser.UserId);
            if (userDb == null)
                throw new Exception("Invalid username or password");
            HMACSHA256 hMACSHA256 = new HMACSHA256(userDb.Key);
            var userPassword = hMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));
            for (int i = 0; i < userPassword.Length; i++)
            {
                if (userPassword[i] != userDb.Password[i])
                    throw new Exception("Invalid username or password");
            }
            var result = new LoginResponseDto
            {
                Role = userDb.Role,
                Token = _tokenService.GenerateToken(userDb)

            };
            return result;
        }
        catch (System.Exception e)
        {
            throw e;
        }
        
    }
}