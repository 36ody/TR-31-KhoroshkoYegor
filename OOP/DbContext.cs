using System.Collections.Generic;

public class DbContext
{
    public List<User> Users { get; set; }
    public List<Product> Products { get; set; }

    public DbContext()
    {
        Users = new List<User>
        {
            new User("user1", "password1", 100),
            new User("user2", "password2", 200)
        };

        Products = new List<Product>
        {
            new Product("Product1", 10),
            new Product("Product2", 20),
            new Product("Product3", 30)
        };
    }
}