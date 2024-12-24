public class LoginUserCommand : ICommand
{
    private readonly IUserService _userService;

    public LoginUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        var user = _userService.Login(username, password);
        if (user != null)
        {
            Console.WriteLine("Login successful.");
            Program.UserMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Login with an existing user.");
    }
}