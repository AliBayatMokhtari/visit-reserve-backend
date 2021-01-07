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
    public class PatientsController : ControllerBase
    {
        private readonly DatabaseContext dbContext;

        public PatientsController(DatabaseContext context) { dbContext = context; }

        // GET
        [HttpGet]
        public IEnumerable<Patient> GetPatients()
        {
            return dbContext.Patients.ToList();
        }


        // GET with id
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await dbContext.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }



        // POST
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            await dbContext.Patients.AddAsync(patient);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }


        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Patient>> PutPatient(Patient patient, int id)
        {
            var p = await dbContext.Patients.FindAsync(patient);

            if (p == null)
            {
                return NotFound();
            }

            // implement put
            return NoContent();
        }


        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await dbContext.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            dbContext.Patients.Remove(patient);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}