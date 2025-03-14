using Domain;

namespace Infrastructure;

public interface ICustomerService
{
    public void AddCustomer(Customers customers);
    public void GetAllCustomers();
    public void GetCustomerById(int id);
    public void UpdateCustomer();
    public void DeleteCustomerById(int id);

}