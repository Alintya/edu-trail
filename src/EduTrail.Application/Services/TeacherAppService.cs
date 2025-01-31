using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;

namespace EduTrail.Application.Services;

public class TeacherAppService(ITeacherRepository teacherRepository, IClassRepository classRepository) : ITeacherAppService
{
    public Task AddClassToTrailAsync(Guid classId, Guid trailId)
    {
        throw new NotImplementedException();
    }

    public Task AddTrailToClassAsync(Guid trailId, Guid classId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateClassAsync(string name, Guid teacherId)
    {
        var newClass = new Class
        {
            Name = name,
            TeacherId = teacherId
        };
        await classRepository.AddAsync(newClass);
    }

    public async Task<Guid> CreateTeacherAsync(string firstName, string lastName)
    {
        return (await teacherRepository.AddAsync(new Teacher
        {
            FirstName = firstName,
            LastName = lastName
        })).Id;
    }

    public Task CreateTrailAsync(string name, Guid teacherId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteClassAsync(Guid classId)
    {
        await classRepository.DeleteByIdAsync(classId);
    }

    public Task DeleteTrailAsync(Guid trailId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GenerateClassCodeAsync(Guid classId)
    {
        return "12345";  // TODO
    }

    public Task<Class> GetClassAsync(Guid classId)
    {
        return classRepository.GetClassWithStudentsAsync(classId);
    }

    public async Task<IEnumerable<Class>> GetClassesAsync(Guid teacherId)
    {
        return await classRepository.GetClassesWithStudentsByTeacherIdAsync(teacherId);
    }

    public Task<IEnumerable<Class>> GetClassesForTrailAsync(Guid trailId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StudentProgress>> GetStudentProgressForTrailAndClassAsync(Guid trailId, Guid classId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LearningTrail>> GetTrailsAsync(Guid teacherId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LearningTrail>> GetTrailsForClassAsync(Guid classId)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> OpenSubmissionAsync(Guid studentId, Guid assignmentId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClassFromTrailAsync(Guid classId, Guid trailId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveStudentFromClassAsync(Guid studentId, Guid classId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTrailFromClassAsync(Guid trailId, Guid classId)
    {
        throw new NotImplementedException();
    }

    public Task ResetStudentPasswordAsync(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public Task SetClassNameAsync(Guid classId, string name)
    {
        throw new NotImplementedException();
    }

    public Task SetStudentClassAsync(Guid studentId, string className)
    {
        throw new NotImplementedException();
    }

    public Task SetStudentNameAsync(Guid studentId, string surName, string lastName)
    {
        throw new NotImplementedException();
    }

    public Task SetTrailNameAsync(Guid trailId, string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTrailAsync(Guid trailId, LearningTrail trail)
    {
        throw new NotImplementedException();
    }
}
