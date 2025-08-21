
using Microsoft.EntityFrameworkCore;

public class UserRepository : RepositoryDb<int, User>
{
    public UserRepository(HrContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<User>> GetAll()
    {
        var user = await _context.Users.ToListAsync();
        return user;
    }

    public async override Task<User> GetByKey(int key)
    {
        var users = await _context.Users.SingleOrDefaultAsync(d => d.UserId == key);
        return users;
    }
}