using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace test.Core.StoreAggregate;

public class Buy : EntityBase, IAggregateRoot
{
  private readonly List<Product> _products = new();

  public Buy(Customer customer, IEnumerable<Product> products)
  {
    UpdateCustomer(customer);
    AddProducts(products);
  }

  public Customer Customer { get; private set; } = default!;
  public IReadOnlyCollection<Product> Products => new ReadOnlyCollection<Product>(_products);

  public Buy UpdateCustomer(Customer customer)
  {
    Customer = Guard.Against.Null(customer, nameof(customer));
    return this;
  }

  public Buy AddProduct(Product product)
  {
    _products.Add(Guard.Against.Null(product, nameof(product)));
    return this;
  }

  public Buy RemoveProduct(Product product)
  {
    _products.Remove(Guard.Against.Null(product, nameof(product)));
    if (!_products.Any())
    {
      throw new InvalidOperationException("A buy must contain at least one product.");
    }

    return this;
  }

  private void AddProducts(IEnumerable<Product> products)
  {
    Guard.Against.Null(products, nameof(products));
    foreach (var product in products)
    {
      AddProduct(product);
    }

    if (!_products.Any())
    {
      throw new ArgumentException("A buy must contain at least one product.", nameof(products));
    }
  }
}
