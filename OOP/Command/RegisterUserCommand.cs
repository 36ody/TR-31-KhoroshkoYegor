public class RegisterUserCommand : ICommand
{
    private readonly IUserService _userService;

    public RegisterUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        Console.Write("Enter initial balance: ");
        decimal initialBalance = decimal.Parse(Console.ReadLine());
        var user = new User(username, password, initialBalance);
        _userService.Register(user);
        Console.WriteLine("User registered successfully.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Register a new user.");
    }
}