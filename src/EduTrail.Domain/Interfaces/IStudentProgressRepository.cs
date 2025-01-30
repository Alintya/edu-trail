using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface IStudentProgressRepository : IRepository<StudentProgress>
{
    Task<StudentProgress?> GetStudentProgressForAssignmentAsync(Guid studentId, Guid assignmentId);
}
