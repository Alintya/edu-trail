using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface IAssignmentRepository : IRepository<Assignment>
{
    Task<Assignment?> GetAssignmentWithSubmissionsAsync(Guid id);
    Task<IEnumerable<Assignment>> GetAssignmentsByModuleAsync(Guid moduleId);
    Task<IEnumerable<Assignment>> GetPendingAssignmentsByStudentAsync(Guid studentId);
}
