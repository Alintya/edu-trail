using EduTrail.Domain.Entities;

namespace EduTrail.Domain.Interfaces;

public interface ILearningTrailRepository : IRepository<LearningTrail>
{
    Task<LearningTrail?> GetTrailWithModulesAsync(Guid id);
    Task<IEnumerable<LearningTrail>> GetTrailsByTeacherAsync(Guid teacherId);
}