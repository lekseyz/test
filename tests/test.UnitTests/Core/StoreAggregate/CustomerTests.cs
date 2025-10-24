using System;

namespace test.UnitTests.Core.StoreAggregate;

public class CustomerTests
{
  private static Customer CreateCustomer() => new("CUST-1", "Alice", "555-1234");

  [Fact]
  public void Constructor_Sets_All_Properties()
  {
    var customer = CreateCustomer();

    customer.CustomerId.ShouldBe("CUST-1");
    customer.Name.ShouldBe("Alice");
    customer.Phone.ShouldBe("555-1234");
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void UpdateCustomerId_Throws_For_Invalid_Value(string? value)
  {
    var customer = CreateCustomer();

    Should.Throw<ArgumentException>(() => customer.UpdateCustomerId(value!));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void UpdateName_Throws_For_Invalid_Value(string? value)
  {
    var customer = CreateCustomer();

    Should.Throw<ArgumentException>(() => customer.UpdateName(value!));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void UpdatePhone_Throws_For_Invalid_Value(string? value)
  {
    var customer = CreateCustomer();

    Should.Throw<ArgumentException>(() => customer.UpdatePhone(value!));
  }
}
