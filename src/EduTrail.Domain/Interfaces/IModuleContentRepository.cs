using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface IModuleContentRepository : IRepository<AssignmentContent>
{
    Task<IEnumerable<AssignmentContent>> GetContentsByAssignmentAsync(Guid moduleId);
}
