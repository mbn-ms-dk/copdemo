
using Customers;
using Testcontainers.PostgreSql;

namespace CustomerService.Tests;

public sealed class CustomerServiceTest : IAsyncLifetime
{

    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
    .WithImage("postgres:15-alpine")
    .Build();

    public Task DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }

    public Task InitializeAsync()
    {
        return _postgreSqlContainer.StartAsync();
    }

    //Create fact that should return two customers
    [Fact]
    public void ShouldReturnTwoCustomers()
    {
        //Arrange
        var customerService = new CustomerService(new DbConnectionProvider(_postgreSqlContainer.GetConnectionString()));

        var customer1 = new Customer(1, "John", "Doe", "john@sample.com");
        var customer2 = new Customer(2, "Jane", "Doe", "jane@sample.com");

        //Act
        customerService.CreateCustomer(customer1);
        customerService.CreateCustomer(customer2);

        //Assert
        var customers = customerService.GetCustomers().ToList();
        Assert.Equal(2, customers.Count);
    }
}