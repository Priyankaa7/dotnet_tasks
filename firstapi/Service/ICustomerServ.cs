namespace firstapi.Service
{
    public interface ICustomerServ<PriyankaCustomer>
    {
        List<PriyankaCustomer> GetAllCustomers();
        void AddCustomer(PriyankaCustomer c);
        void UpdateCustomer(int id, PriyankaCustomer c);
        PriyankaCustomer GetCustomerById(int id);
        void DeleteCustomer(int id);
    }
}