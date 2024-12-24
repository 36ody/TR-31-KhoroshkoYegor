public class Product
{
    private static int _nextId = 1;

    public int Id { get; private set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Id = _nextId++;
        Name = name;
        Price = price;
    }
}