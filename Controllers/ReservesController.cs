using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Models.Data;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReservesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public IEnumerable<Reserve> GetReserves()
        {
            return _context.Reserves.ToList();
        }


        // GET with id
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserve>> GetReserve(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);

            if (reserve == null)
            {
                return NotFound();
            }

            return reserve;
        }


        // Post 
        [HttpPost]
        public async Task<ActionResult<Reserve>> PostReserve(Reserve reserve)
        {
            await _context.Reserves.AddAsync(reserve);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReserve), new {id = reserve.Id},
                reserve);
        }


        // PUT


        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserve>> DeleteReserve(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);

            if (reserve == null)
            {
                return NotFound();
            }

            _context.Reserves.Remove(reserve);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}