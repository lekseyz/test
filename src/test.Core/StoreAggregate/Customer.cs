namespace test.Core.StoreAggregate;

public class Customer : EntityBase
{
  public Customer(string customerId, string name, string phone)
  {
    UpdateCustomerId(customerId);
    UpdateName(name);
    UpdatePhone(phone);
  }

  public string CustomerId { get; private set; } = default!;
  public string Name { get; private set; } = default!;
  public string Phone { get; private set; } = default!;

  public Customer UpdateCustomerId(string customerId)
  {
    CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
    return this;
  }

  public Customer UpdateName(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    return this;
  }

  public Customer UpdatePhone(string phone)
  {
    Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
    return this;
  }
}
