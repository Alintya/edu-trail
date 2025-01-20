using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface IAssignmentRepository : IRepository<Assignment>
{
    Task<Assignment?> GetAssignmentWithContentsAsync(Guid id);
    Task<Assignment?> GetAssignmentWithSubmissionsAsync(Guid id);
    Task<IEnumerable<Assignment>> GetAssignmentsByModuleAsync(Guid moduleId);
    Task<IEnumerable<Assignment>> GetPendingAssignmentsByStudentAsync(Guid studentId);
    Task<IEnumerable<Assignment>> GetAssignmentsByTagAsync(string tag);
}
