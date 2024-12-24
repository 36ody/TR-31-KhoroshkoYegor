namespace OOP.Repository;

public interface IUserRepository
{
    void Create(User user);
    User Read(string username);
    void Update(User user);
    void Delete(string username);
    List<User> GetAll();
}