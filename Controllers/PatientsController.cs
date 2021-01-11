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
    public class PatientsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PatientsController(DatabaseContext context) { _context = context; }

        // GET
        [HttpGet]
        public async Task<IEnumerable<PatientDto>> GetPatients()
        {
            var patients = await _context.Patients
                .Select(p => new PatientDto(p))
                .ToListAsync();

            return patients;
        }


        // GET with id
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            var patientDto = new PatientDto(patient);

            return patientDto;
        }



        // POST
        [HttpPost]
        public async Task<ActionResult<PatientDto>> PostPatient(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            var patientDto = new PatientDto(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patientDto);
        }


        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<PatientDto>> PutPatient(Patient patient, int id)
        {

            if (id != patient.Id)
            {
                return BadRequest();
            }

            var p = await _context.Patients.FindAsync(patient);

            if (p == null)
            {
                return NotFound();
            }

            p.Id = patient.Id;
            p.Name = patient.Name ?? p.Name;
            p.Family = patient.Family ?? p.Family;
            p.PhoneNumber = patient.PhoneNumber ?? p.PhoneNumber;
            p.MobileNumber = patient.MobileNumber ?? p.MobileNumber;
            p.Age = patient.Age;

            await _context.SaveChangesAsync();

            var patientDto = new PatientDto(p);

            return patientDto;
        }


        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientDto>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}