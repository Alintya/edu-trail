using EduTrail.Domain.Entities;

namespace EduTrail.Application.Interfaces;

public interface ITeacherAppService
{
    Task<Guid> CreateTeacherAsync(string firstName, string lastName);

    Task<IEnumerable<Class>> GetClassesAsync(Guid teacherId);
    Task CreateClassAsync(string name, Guid teacherId);
    Task SetClassNameAsync(Guid classId, string name);
    Task DeleteClassAsync(Guid classId);
    Task<int> GenerateClassCodeAsync(Guid classId);
    Task<IEnumerable<LearningTrail>> GetTrailsForClassAsync(Guid classId);
    Task AddTrailToClassAsync(Guid trailId, Guid classId);
    Task RemoveTrailFromClassAsync(Guid trailId, Guid classId);

    Task RemoveStudentFromClassAsync(Guid studentId, Guid classId);
    Task ResetStudentPasswordAsync(Guid studentId);
    Task SetStudentNameAsync(Guid studentId, string surName, string lastName);
    Task SetStudentClassAsync(Guid studentId, string className);

    Task<IEnumerable<LearningTrail>> GetTrailsAsync(Guid teacherId);
    Task CreateTrailAsync(string name, Guid teacherId);
    Task DeleteTrailAsync(Guid trailId);
    Task SetTrailNameAsync(Guid trailId, string name);
    Task UpdateTrailAsync(Guid trailId, LearningTrail trail);  // Update trail as a whole for now
    Task<IEnumerable<Class>> GetClassesForTrailAsync(Guid trailId);
    Task AddClassToTrailAsync(Guid classId, Guid trailId);  // Same as AddTrailToClassAsync
    Task RemoveClassFromTrailAsync(Guid classId, Guid trailId);  // Same as RemoveTrailFromClassAsync

    Task<IEnumerable<StudentProgress>> GetStudentProgressForTrailAndClassAsync(Guid trailId, Guid classId);
    Task<Stream> OpenSubmissionAsync(Guid studentId, Guid assignmentId);
}
