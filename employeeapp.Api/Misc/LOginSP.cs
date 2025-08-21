

public class LOginSP : ILOginSP
{
    private readonly HrContext _context;

    public LOginSP(HrContext context)
    {
        _context = context;
    }
    public async Task<User> ExecuteSP(int UserId)
    {
        var result = (await _context.GetLoginProc(UserId));
        if (result == null || result.Count()==0)
            throw new Exception("Invalid userid");
        var loginUser = result.ToList()[0];
        return new User
        {
            UserId = loginUser.UserId,
            Password = loginUser.Password,
            Key = loginUser.Key,
            Role = loginUser.Role
        };
    }
}