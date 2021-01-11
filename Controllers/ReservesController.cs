using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Models.Data;
using TodoApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<ReserveDto>> GetReserves()
        {
            var reserves = await _context.Reserves
                .Select(r => new ReserveDto(r))
                .ToListAsync();

            return reserves;
        }


        // GET with id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReserveDto>> GetReserve(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);

            if (reserve == null)
            {
                return NotFound();
            }

            var reserveDto = new ReserveDto(reserve);

            return reserveDto;
        }


        // Post 
        [HttpPost]
        public async Task<ActionResult<ReserveDto>> PostReserve(Reserve reserve)
        {
            await _context.Reserves.AddAsync(reserve);

            await _context.SaveChangesAsync();

            var reserveDto = new ReserveDto(reserve);

            return CreatedAtAction(nameof(GetReserve), new { id = reserve.Id }, reserveDto);
        }


        // PUT


        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReserveDto>> DeleteReserve(int id)
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