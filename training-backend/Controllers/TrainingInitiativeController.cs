using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using training_backend.Data;
using training_backend.models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace training_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingInitiativeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrainingInitiativeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Training
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingInitiative>>> GetTrainings()
        {
            return await _context.Trainings.ToListAsync();
        }

        // GET: api/Training/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingInitiative>> GetTraining(int id)
        {
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
                return NotFound();

            return training;
        }

        // POST: api/Training
        [HttpPost]
        public async Task<ActionResult<TrainingInitiative>> PostTraining(TrainingInitiative training)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTraining), new { id = training.Id }, training);
        }

        // PUT: api/Training/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(int id, TrainingInitiative training)
        {
            if (id != training.Id)
                return BadRequest();

            // Find the existing training record
            var existingTraining = await _context.Trainings.FindAsync(id);
            if (existingTraining == null)
                return NotFound();

            // Update properties
            existingTraining.Name = training.Name;
            existingTraining.UpdateDate = DateTime.UtcNow; // Set the current date and time

            _context.Entry(existingTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        //TrainingInitiative 

        // DELETE: api/Training/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
                return NotFound();

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingExists(int id) =>
            _context.Trainings.Any(e => e.Id == id);
    }
}
