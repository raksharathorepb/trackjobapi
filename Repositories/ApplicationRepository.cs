
using JobTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using TrackJobAPI.Data;
using TrackJobAPI.Interfaces;


namespace TrackJobAPI.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobApplication>> GetAllAsync() =>
            await _context.JobApplications.ToListAsync();

        public async Task<(IEnumerable<JobApplication> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.JobApplications.AsQueryable();
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(j => j.DateApplied)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }


        public async Task<JobApplication?> GetByIdAsync(int id) =>
            await _context.JobApplications.FindAsync(id);

        public async Task AddAsync(JobApplication application)
        {
            await _context.JobApplications.AddAsync(application);
        }

        public Task UpdateAsync(JobApplication application)
        {
            _context.Entry(application).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var job = await _context.JobApplications.FindAsync(id);
            if (job != null)
                _context.JobApplications.Remove(job);
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
