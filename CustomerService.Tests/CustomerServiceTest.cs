
using Customers;
using Testcontainers.PostgreSql;

namespace Customers.Tests;

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

        /// <summary>
        /// Creates a new instance of the Customer class with the specified properties.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
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