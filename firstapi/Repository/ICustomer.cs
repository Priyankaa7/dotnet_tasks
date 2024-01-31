using firstapi.Models;
namespace firstapi.Repository
{
    public interface ICustomer<PriyankaCustomer>
    {
        List<PriyankaCustomer> GetAllCustomers();
        void AddCustomer(PriyankaCustomer c);
        void UpdateCustomer(int id, PriyankaCustomer c);
        PriyankaCustomer GetCustomerById(int id);
        void DeleteCustomer(int id);
    }
}