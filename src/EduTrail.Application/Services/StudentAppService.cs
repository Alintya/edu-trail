using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;

namespace EduTrail.Application.Services;

public class StudentAppService(IStudentProgressRepository studentProgressRepository, IFileManagementAppService fileManagementService) : IStudentAppService
{
    private readonly IStudentProgressRepository studentProgressRepository = studentProgressRepository;
    private readonly IFileManagementAppService fileManagementService = fileManagementService;

    public Task CreateStudentAsync(string surName, string lastName, string className, string password)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LearningTrail>> GetTrailsAsync(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public Task JoinClassAsync(int classCode, Guid studentId)
    {
        throw new NotImplementedException();
    }

    public async Task MarkAssignmentAsCompletedAsync(Guid assignmentId, Guid studentId)
    {
        var studentProgress = await studentProgressRepository.GetStudentProgressForAssignmentAsync(studentId, assignmentId) 
            ?? throw new Exception($"Student progress for student with ID {studentId} and assignment with ID {assignmentId} not found.");
        studentProgress.CompletedAt = DateTime.UtcNow;
        await studentProgressRepository.UpdateAsync(studentProgress);
    }

    public async Task UploadSolutionAsync(Guid assignmentId, Guid studentId, Stream solution, string contentType)
    {
        await fileManagementService.UploadFileAsync(solution, $"{studentId}_{assignmentId}_solution", contentType, solution.Length);
    }
}
