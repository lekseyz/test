using System;

namespace test.UnitTests.Core.StoreAggregate;

public class ProductTests
{
  private static Product CreateProduct() => new("Widget", 9.99m, "Useful widget");

  [Fact]
  public void Constructor_Sets_All_Properties()
  {
    var product = CreateProduct();

    product.Name.ShouldBe("Widget");
    product.Price.ShouldBe(9.99m);
    product.Description.ShouldBe("Useful widget");
  }

  [Fact]
  public void Constructor_Throws_When_Name_Is_Invalid()
  {
    Should.Throw<ArgumentException>(() => new Product(string.Empty, 9.99m, "Useful widget"));
  }

  [Fact]
  public void Constructor_Throws_When_Price_Is_Not_Positive()
  {
    Should.Throw<ArgumentException>(() => new Product("Widget", 0m, "Useful widget"));
  }

  [Fact]
  public void Constructor_Throws_When_Description_Is_Invalid()
  {
    Should.Throw<ArgumentException>(() => new Product("Widget", 9.99m, string.Empty));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void UpdateName_Throws_For_Invalid_Value(string? value)
  {
    var product = CreateProduct();

    Should.Throw<ArgumentException>(() => product.UpdateName(value!));
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void UpdatePrice_Throws_For_NonPositive_Value(decimal price)
  {
    var product = CreateProduct();

    Should.Throw<ArgumentException>(() => product.UpdatePrice(price));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void UpdateDescription_Throws_For_Invalid_Value(string? value)
  {
    var product = CreateProduct();

    Should.Throw<ArgumentException>(() => product.UpdateDescription(value!));
  }
}
