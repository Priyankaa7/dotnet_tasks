using firstapi.Models;
namespace firstapi.Repository
{
    public class CustomerRepo : ICustomer<PriyankaCustomer>
    {
        private readonly Ace52024Context db;
        public CustomerRepo() {}

        public CustomerRepo(Ace52024Context _db)
        {
            db = _db;
        }

        public void AddCustomer(PriyankaCustomer c)
        {
            db.PriyankaCustomers.Add(c);
            db.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            PriyankaCustomer c = db.PriyankaCustomers.Find(id);
            db.PriyankaCustomers.Remove(c);
            db.SaveChanges();
        }

        public List<PriyankaCustomer> GetAllCustomers()
        {
            return db.PriyankaCustomers.ToList();
        }

        public PriyankaCustomer GetCustomerById(int id)
        {
            return db.PriyankaCustomers.Find(id);
        }

        public void UpdateCustomer(int id, PriyankaCustomer c)
        {
            db.PriyankaCustomers.Update(c);
            db.SaveChanges();
        }
    }
}