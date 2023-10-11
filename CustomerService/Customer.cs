namespace Customers;

public readonly record struct Customer(long Id, string FirstName, string LastName, string Email);
