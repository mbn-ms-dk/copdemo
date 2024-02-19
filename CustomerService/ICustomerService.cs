using Customers;

public interface ICustomerService
{
    void CreateCustomersTable();
    IEnumerable<Customer> GetCustomers();
    void CreateCustomer(Customer customer);
}