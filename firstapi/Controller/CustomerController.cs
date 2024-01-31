using firstapi.Models;
using firstapi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServ<PriyankaCustomer> _custServ;

        public CustomerController(ICustomerServ<PriyankaCustomer> custServ)
        {
            _custServ = custServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriyankaCustomer>>> GetCustomers()
        {
            return _custServ.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriyankaCustomer>> GetCustomer(int id)
        {
            var cust = _custServ.GetCustomerById(id);
            if (cust == null)
            {
                return NotFound();
            }
            return cust;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, PriyankaCustomer cust)
        {
            if (id != cust.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                _custServ.UpdateCustomer(id, cust);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriyankaCustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PriyankaCustomer>> PostCustomer(PriyankaCustomer cust)
        {
            try
            {
                _custServ.AddCustomer(cust);
            }
            catch(DbUpdateException)
            {
                if (PriyankaCustomerExists(cust.CustomerId))
                {
                    return Conflict();
                }
                else 
                {
                    throw;
                }
            }
            return CreatedAtAction("GetCustomer", new { id = cust.CustomerId }, cust);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var cust = _custServ.GetCustomerById(id);
            if (cust == null)
            {
                return NotFound();
            }
            _custServ.DeleteCustomer(id);
            return NoContent();
        }

        private bool PriyankaCustomerExists(int id)
        {
            PriyankaCustomer c = _custServ.GetCustomerById(id);
            if (c != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }        
    }
}