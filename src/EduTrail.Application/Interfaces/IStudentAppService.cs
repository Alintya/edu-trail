using EduTrail.Domain.Entities;

namespace EduTrail.Application.Interfaces;

public interface IStudentAppService
{
    Task CreateStudentAsync(string surName, string lastName, string className, string password);

    Task JoinClassAsync(int classCode, Guid studentId);
    Task<IEnumerable<LearningTrail>> GetTrailsAsync(Guid studentId);
    Task MarkAssignmentAsCompletedAsync(Guid assignmentId, Guid studentId);
    Task UploadSolutionAsync(Guid assignmentId, Guid studentId, Stream solution, string contentType);
}
