public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public List<Product> PurchaseHistory { get; set; }

    public User(string username, string password, decimal initialBalance)
    {
        Username = username;
        Password = password;
        Balance = initialBalance;
        PurchaseHistory = new List<Product>();
    }
}