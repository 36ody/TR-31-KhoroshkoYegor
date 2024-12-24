public interface IUserService
{
    void Register(User user);
    User Login(string username, string password);
    void AddBalance(string username, decimal amount);
    User ViewProfile(string username); 
}