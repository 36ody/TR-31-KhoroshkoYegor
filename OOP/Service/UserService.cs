using OOP.Repository;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Register(User user)
    {
        _userRepository.Create(user);
    }

    public User Login(string username, string password)
    {
        var user = _userRepository.Read(username);
        if (user != null && user.Password == password)
        {
            return user;
        }
        return null;
    }

    public void AddBalance(string username, decimal amount)
    {
        var user = _userRepository.Read(username);
        if (user != null)
        {
            user.Balance += amount;
            _userRepository.Update(user);
        }
    }

    public User ViewProfile(string username)
    {
        return _userRepository.Read(username);
    }
}