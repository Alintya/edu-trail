using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface IModuleContentRepository : IRepository<ModuleContent>
{
    Task<IEnumerable<ModuleContent>> GetContentsByAssignmentAsync(Guid moduleId);
}
