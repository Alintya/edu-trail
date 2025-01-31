using EduTrail.Domain.Entities;

namespace EduTrail.Application.Interfaces;

public interface ITrailAppService
{
    Task<LearningTrail?> GetTrailByIdAsync(Guid id);
    Task<Stream> OpenAssignmentContentAsync(Guid assignmentContentId);
}
