using OOP.Repository;

public class UserRepository : IUserRepository
{
    private readonly DbContext _context;

    public UserRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
    }

    public User Read(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public void Update(User user)
    {
        var existingUser = Read(user.Username);
        if (existingUser != null)
        {
            existingUser.Password = user.Password;
            existingUser.Balance = user.Balance;
            existingUser.PurchaseHistory = user.PurchaseHistory;
        }
    }

    public void Delete(string username)
    {
        var user = Read(username);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }
    
    public List<User> GetAll()
    {
        return _context.Users;
    }
}