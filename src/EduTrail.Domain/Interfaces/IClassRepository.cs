using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface IClassRepository : IRepository<Class>
{
    Task<IEnumerable<Class>> GetClassesWithStudentsByTeacherIdAsync(Guid teacherId);
    Task<Class> GetClassWithStudentsAsync(Guid id);
}
