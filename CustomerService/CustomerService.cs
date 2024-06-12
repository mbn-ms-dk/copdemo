using Npgsql;
using Microsoft.Extensions.Logging;

namespace Customers;

public sealed class CustomerService
{
    private readonly DbConnectionProvider _dbConnectionProvider;

    public CustomerService(DbConnectionProvider dbConnectionProvider)
    {
        _dbConnectionProvider = dbConnectionProvider;
        CreateCustomersTable();
    }
    private void CreateCustomersTable()
    {
        Console.WriteLine("Creating customers table");
        using var connection = _dbConnectionProvider.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS customers (id BIGINT NOT NULL, first_name TEXT NOT NULL, last_name TEXT, email TEXT NOT NULL,  PRIMARY KEY (id))";
        command.Connection?.Open();
        command.ExecuteNonQuery();
    }

  //create method to get customers
    public IEnumerable<Customer> GetCustomers()
    {
        Console.WriteLine("Getting customers");
        using var connection = _dbConnectionProvider.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT id, first_name, last_name, email FROM customers";
        command.Connection?.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new Customer
            {
                Id = reader.GetInt64(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Email = reader.GetString(3)
            };
        }
    }

    //Create method to Create Customer with Customer as parameter
    public void CreateCustomer(Customer customer)
    {
        Console.WriteLine("$Creating customer with id {customer.Id} and " +
            $"email {customer.Email}");
        using var connection = _dbConnectionProvider.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO customers (id, first_name, last_name, email) VALUES (@id, @first_name, @last_name, @email)";
        command.Parameters.AddWithValue("id", customer.Id);
        command.Parameters.AddWithValue("first_name", customer.FirstName);
        command.Parameters.AddWithValue("last_name", customer.LastName);
        command.Parameters.AddWithValue("email", customer.Email);
        command.Connection?.Open();
        command.ExecuteNonQuery();
    }
}