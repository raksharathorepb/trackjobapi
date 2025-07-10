using JobTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using TrackJobAPI.Interfaces;

namespace TrackJobAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationRepository _repo;

        public ApplicationsController(IApplicationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var (items, totalCount) = await _repo.GetPagedAsync(pageNumber, pageSize);
            return Ok(new { data = items, totalCount });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetById(int id)
        {
            var app = await _repo.GetByIdAsync(id);
            return app == null ? NotFound() : Ok(app);
        }

        [HttpPost]
        public async Task<ActionResult> Create(JobApplication app)
        {
            app.DateApplied = DateTime.UtcNow;
            await _repo.AddAsync(app);
            await _repo.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = app.Id }, app);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JobApplication app)
        {
            if (id != app.Id) return BadRequest("ID mismatch");
            
            await _repo.UpdateAsync(app);
            await _repo.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
            return NoContent();
        }
    }
}
