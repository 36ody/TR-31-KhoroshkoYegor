public class Program
{
    private static IUserService _userService;
    private static IProductService _productService;

    public static void Main(string[] args)
    {
        var dbContext = new DbContext();
        var userRepository = new UserRepository(dbContext);
        var productRepository = new ProductRepository(dbContext);
        _userService = new UserService(userRepository);
        _productService = new ProductService(productRepository, userRepository);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            ICommand command = choice switch
            {
                "1" => new RegisterUserCommand(_userService),
                "2" => new LoginUserCommand(_userService),
                "3" => null,
                _ => null
            };

            if (command != null)
            {
                command.Execute();
            }
            else if (choice == "3")
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    public static void UserMenu(User user)
    {
        var commands = new List<ICommand>
        {
            new ViewProductsCommand(_productService),
            new AddBalanceCommand(_userService, user.Username),
            new PurchaseProductCommand(_productService, user.Username),
            new ViewProfileCommand(_userService, user.Username),
            new AddProductCommand(_productService)
        };

        while (true)
        {
            Console.WriteLine("Choose an option:");
            foreach (var command in commands)
            {
                command.DisplayOptions();
            }
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int commandIndex) && commandIndex >= 1 && commandIndex <= commands.Count)
            {
                commands[commandIndex - 1].Execute();
            }
            else if (commandIndex == 6)
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}