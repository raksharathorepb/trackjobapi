using JobTrackerAPI.Models;

namespace TrackJobAPI.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetAllAsync();
        Task<(IEnumerable<JobApplication> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
        Task<JobApplication?> GetByIdAsync(int id);
        Task AddAsync(JobApplication application);
        Task UpdateAsync(JobApplication application);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
