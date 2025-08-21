public interface IAuthenticationService
{
    public Task<LoginResponseDto> Login(LoginRequestDto loginUser);
}