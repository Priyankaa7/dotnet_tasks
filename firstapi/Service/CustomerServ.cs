using firstapi.Models;
using firstapi.Repository;

namespace firstapi.Service
{
    public class CustomerServ : ICustomerServ<PriyankaCustomer>
    {
        private readonly ICustomer<PriyankaCustomer> cust;
        public CustomerServ() {}

        public CustomerServ(ICustomer<PriyankaCustomer> _cust)
        {
            cust = _cust;
        }

        public void AddCustomer(PriyankaCustomer c)
        {
            cust.AddCustomer(c);
        }

        public void DeleteCustomer(int id)
        {
            cust.DeleteCustomer(id);
        }

        public List<PriyankaCustomer> GetAllCustomers()
        {
            return cust.GetAllCustomers();
        }

        public PriyankaCustomer GetCustomerById(int id)
        {
            return cust.GetCustomerById(id);
        }

        public void UpdateCustomer(int id, PriyankaCustomer c)
        {
            cust.UpdateCustomer(id, c);
        }
    }
}