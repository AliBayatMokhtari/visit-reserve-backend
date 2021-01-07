using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Models.Data;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OfficesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<Office>> GetOffices()
        {
            return await _context.Offices.Include(o => o.Doctor).ToListAsync();
        }


        // GET with id
        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffice(int id)
        {
            var office = await _context.Offices.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return office;
        }


        // POST
        [HttpPost]
        public async Task<ActionResult<Office>> PostOffice(Office office)
        {
            await _context.Offices.AddAsync(office);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOffice), new { id = office.Id },
                office);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Office>> PutOffice(Office office, int id)
        {
            var o = await _context.Offices.FindAsync(id);

            if (o == null)
            {
                return NotFound();
            }

            // implement put
            return NoContent();
        }


        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Office>> DeleteOffice(int id)
        {
            var office = await _context.Offices.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            _context.Offices.Remove(office);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}