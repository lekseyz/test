namespace test.Core.StoreAggregate;

public class Product : EntityBase
{
  public Product(string name, decimal price, string description)
  {
    UpdateName(name);
    UpdatePrice(price);
    UpdateDescription(description);
  }

  public string Name { get; private set; } = default!;
  public decimal Price { get; private set; }
  public string Description { get; private set; } = default!;

  public Product UpdateName(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    return this;
  }

  public Product UpdatePrice(decimal price)
  {
    Price = Guard.Against.NegativeOrZero(price, nameof(price));
    return this;
  }

  public Product UpdateDescription(string description)
  {
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
    return this;
  }
}
