using Tatesoft.WebAPI.Exceptions;

namespace Tatesoft.WebAPI.Services;

public interface ICustomerService
{
    Customer? GetCustomer(int id);
    Customer? GetCustomerOrDefault(int id);
    List<Customer> GetCustomers();
}

public class CustomerService : ICustomerService
{
    private Dictionary<int, Customer> Customers = new()
    {
        { 1, new Customer(1, "John Cleese") },
        { 2, new Customer(2, "Terry Gilliam") },
        { 3, new Customer(3, "Graham Chapman") },
        { 4, new Customer(4, "Eric Idle") },
        { 5, new Customer(5, "Michael Palin") },
        { 6, new Customer(6, "Terry Jones") }
    };

    public Customer? GetCustomer(int id)
    {
        if (!Customers.ContainsKey(id))
        {
            throw new EntityNotFoundException();
        }

        return Customers[id];
    }

    public Customer? GetCustomerOrDefault(int id)
    {
        return !Customers.ContainsKey(id) ? null : Customers[id];
    }

    public List<Customer> GetCustomers()
    {
        return Customers.Values.ToList();
    }
}

public record Customer(int Id, string CustomerName);