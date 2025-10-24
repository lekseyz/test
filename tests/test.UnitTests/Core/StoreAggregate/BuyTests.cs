using System;

namespace test.UnitTests.Core.StoreAggregate;

public class BuyTests
{
  private static Customer CreateCustomer() => new("CUST-1", "Alice", "555-1234");
  private static Product CreateProduct(string name = "Widget", decimal price = 9.99m) => new(name, price, "Useful widget");

  [Fact]
  public void Constructor_Sets_Customer_And_Products()
  {
    var customer = CreateCustomer();
    var product = CreateProduct();

    var buy = new Buy(customer, new[] { product });

    buy.Customer.ShouldBe(customer);
    buy.Products.ShouldHaveSingleItem();
    buy.Products.ShouldContain(product);
  }

  [Fact]
  public void Constructor_Throws_When_Customer_Is_Null()
  {
    Should.Throw<ArgumentNullException>(() => new Buy(null!, new[] { CreateProduct() }));
  }

  [Fact]
  public void Constructor_Throws_When_Products_Are_Null()
  {
    var customer = CreateCustomer();

    Should.Throw<ArgumentNullException>(() => new Buy(customer, null!));
  }

  [Fact]
  public void Constructor_Throws_When_Products_Are_Empty()
  {
    var customer = CreateCustomer();

    Should.Throw<ArgumentException>(() => new Buy(customer, Array.Empty<Product>()));
  }

  [Fact]
  public void AddProduct_Adds_Item_To_Collection()
  {
    var customer = CreateCustomer();
    var initial = CreateProduct();
    var additional = CreateProduct("Gadget", 19.99m);
    var buy = new Buy(customer, new[] { initial });

    buy.AddProduct(additional);

    buy.Products.Count.ShouldBe(2);
    buy.Products.ShouldContain(additional);
  }

  [Fact]
  public void AddProduct_Throws_When_Product_Is_Null()
  {
    var customer = CreateCustomer();
    var buy = new Buy(customer, new[] { CreateProduct() });

    Should.Throw<ArgumentNullException>(() => buy.AddProduct(null!));
  }

  [Fact]
  public void RemoveProduct_Throws_When_Last_Product_Removed()
  {
    var customer = CreateCustomer();
    var product = CreateProduct();
    var buy = new Buy(customer, new[] { product });

    Should.Throw<InvalidOperationException>(() => buy.RemoveProduct(product));
  }

  [Fact]
  public void RemoveProduct_Removes_Item_When_Collection_Has_Multiple_Entries()
  {
    var customer = CreateCustomer();
    var first = CreateProduct();
    var second = CreateProduct("Gadget", 19.99m);
    var buy = new Buy(customer, new[] { first, second });

    buy.RemoveProduct(first);

    buy.Products.Count.ShouldBe(1);
    buy.Products.ShouldContain(second);
    buy.Products.ShouldNotContain(first);
  }
}
