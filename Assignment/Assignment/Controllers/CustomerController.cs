using Microsoft.AspNetCore.Mvc;
using Assignment.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CustomerInfo customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.CustomerInfo.Add(customer);
                    await _context.SaveChangesAsync();

                   
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    
                    return BadRequest(new { success = false, message = "Error: " + ex.Message });
                }
            }

    
            return BadRequest(new { success = false, message = "Validation failed." });
        }

      

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _context.CustomerInfo.ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { message = "An error occurred while retrieving customer data.", error = ex.Message });
            }
        }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await _context.CustomerInfo.FindAsync(id);
                if (customer == null)
                {
                    return NotFound(new { message = $"Customer with ID {id} not found." });
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { message = "An error occurred while retrieving the customer.", error = ex.Message });
            }
        }


       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerInfo updatedCustomer)
        {
            if (id != updatedCustomer.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.CustomerInfo.FindAsync(id);
            if (existing == null)
                return NotFound();

           
            existing.Name = updatedCustomer.Name;
            existing.GenderId = updatedCustomer.GenderId;
            existing.StateId = updatedCustomer.StateId;
            existing.DistrictId = updatedCustomer.DistrictId;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Customer updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.CustomerInfo.FindAsync(id);
            if (customer == null)
                return NotFound(new { success = false, message = "Customer not found." });

            try
            {
                _context.CustomerInfo.Remove(customer);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "Customer deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = $"Error: {ex.Message}" });
            }
        }


        [HttpGet("states")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _context.States.Select(s => new { s.Id, s.StateName }).ToListAsync();
            return Ok(states);
        }

        [HttpGet("districts/{stateId}")]
        public async Task<IActionResult> GetDistricts(short stateId)
        {
            var districts = await _context.Districts
                .Where(d => d.StateId == stateId)
                .Select(d => new { d.Id, d.DistrictName })
                .ToListAsync();
            return Ok(districts);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveCustomer([FromBody] CustomerInfo customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            
            bool validState = await _context.States.AnyAsync(s => s.Id == customer.StateId);
            if (!validState)
            {
                return BadRequest(new { success = false, message = "Invalid StateId" });
            }

            
            bool validDistrict = await _context.Districts
                .AnyAsync(d => d.Id == customer.DistrictId && d.StateId == customer.StateId);
            if (!validDistrict)
            {
                return BadRequest(new { success = false, message = "Invalid DistrictId for the selected StateId" });
            }

            try
            {
                _context.CustomerInfo.Add(customer); 
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Customer saved successfully" });
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { success = false, message = "Database error: " + dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Unexpected error: " + ex.Message });
            }
        }







    }
}
