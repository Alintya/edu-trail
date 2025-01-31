using EduTrail.Domain.Entities;

namespace EduTrail.Application.Interfaces;

public interface IAdminAppService
{
    Task<IEnumerable<LearningTrail>> GetAllTrailsAsync();
    Task<IEnumerable<Class>> GetAllClassesAsync();
}
