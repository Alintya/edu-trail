using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface ITeacherRepository : IRepository<Teacher>
{
    Task<Teacher?> GetTeacherWithClassesAsync(Guid id);
    Task<Teacher?> GetTeacherWithTrailsAsync(Guid id);
}
