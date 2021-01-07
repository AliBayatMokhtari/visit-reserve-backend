using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Models.Data;
using TodoApi.Models.DTOs;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public DoctorsController(DatabaseContext context) { _context = context; }

        // GET
        [HttpGet]
        public async Task<IEnumerable<DoctorDto>> GetDoctors()
        {
            var doctors = await _context.Doctors.Select(d => new DoctorDto(d)).ToListAsync();

            return doctors;
        }


        // GET with id
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors
                .Where(d => id == d.Id)
                .Select(d => new DoctorDto(d))
                .FirstOrDefaultAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }


        [HttpGet("{id}/offices")]
        public async Task<ActionResult<IEnumerable<OfficeDto>>> GetDoctorOffices(int id)
        {

            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var offices = await _context.Offices
                .Where(o => o.DoctorId == id)
                .Select(o => new OfficeDto(o))
                .ToListAsync();

            return offices;
        }


        // POST
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> PostDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);

            await _context.SaveChangesAsync();
            
            var doctorDto = new DoctorDto(doctor);

            return CreatedAtAction(nameof(GetDoctor), new {id = doctor.Id}, doctorDto);
        }


        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorDto>> PutDoctor(int id, Doctor doctor)
        {

            if (id != doctor.Id)
            {
                return BadRequest();
            }
            
            var d = await _context.Doctors.FindAsync(id);

            if (d == null)
            {
                return NotFound();
            }

            d.Name = doctor.Name ?? d.Name;
            d.Family = doctor.Family ?? d.Family;
            d.VisitFee = doctor.VisitFee;

            await _context.SaveChangesAsync();

            var doctorDto = new DoctorDto(d);

            return doctorDto;
        }


        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}