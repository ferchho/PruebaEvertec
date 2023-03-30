using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEvertec.Models;

namespace TestEvertec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TestContext _dbTest;

        public CustomerController(TestContext dbTest)
        {
            _dbTest = dbTest;
        }

        [HttpGet]
        [Route("Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            List<TblCustomer> customers = await _dbTest.TblCustomers.ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> PostCustomers([FromBody] TblCustomer request)
        {
            await _dbTest.TblCustomers.AddAsync(request);
            await _dbTest.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPut]
        [Route("UpdateCustomer/{id:int}")]
        public async Task<IActionResult> PutCustomers([FromBody] TblCustomer request,int id)
        {
            try
            {
                if (id != request.IdCustomer)
                    return BadRequest("id de cliente no corresponde");

                var updCustomer = await _dbTest.TblCustomers.FindAsync(id);

                if (updCustomer != null)
                {
                    _dbTest.TblCustomers.Update(request);
                    await _dbTest.SaveChangesAsync();
                    return Ok("Cliente Actualizado");
                }
                else
                { 
                    return BadRequest(NotFound($"El id = {id} del cliente, no se encontró"));
                }

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error Actualizando datos");
            }
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id:int}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var delCustomer = await _dbTest.TblCustomers.FindAsync(id);

            if (delCustomer != null)
            {
                _dbTest.TblCustomers.Remove(delCustomer);
                await _dbTest.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Cliente no existe");
            }
        }
    }
}
