using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutApp.Data;
using WorkoutApp.Models;

namespace WorkoutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutExerciseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkoutExerciseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutExercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutExercise>>> GetWorkoutExercises()
        {
            return await _context.WorkoutExercises.ToListAsync();
        }

        // GET: api/WorkoutExercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutExercise>> GetWorkoutExercise(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);

            if (workoutExercise == null)
            {
                return NotFound();
            }

            return workoutExercise;
        }

        // PUT: api/WorkoutExercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutExercise(int id, WorkoutExercise workoutExercise)
        {
            if (id != workoutExercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExerciseExists(id))
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

        // POST: api/WorkoutExercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutExercise>> PostWorkoutExercise(WorkoutExercise workoutExercise)
        {
            _context.WorkoutExercises.Add(workoutExercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutExercise", new { id = workoutExercise.Id }, workoutExercise);
        }

        // DELETE: api/WorkoutExercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutExercise(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null)
            {
                return NotFound();
            }

            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExerciseExists(int id)
        {
            return _context.WorkoutExercises.Any(e => e.Id == id);
        }
    }
}
