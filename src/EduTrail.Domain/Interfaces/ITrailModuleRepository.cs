using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface ITrailModuleRepository : IRepository<TrailModule>
{
    Task<TrailModule?> GetModuleWithContentsAsync(Guid id);
    Task<TrailModule?> GetModuleWithAssignmentsAsync(Guid id);
    Task<IEnumerable<TrailModule>> GetModulesByTrailAsync(Guid trailId);
}
