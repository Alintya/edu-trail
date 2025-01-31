using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;

namespace EduTrail.Application.Services;

public class AdminAppService(ILearningTrailRepository trailRepository, IClassRepository classRepository) : IAdminAppService
{
    private readonly ILearningTrailRepository trailRepository = trailRepository;
    private readonly IClassRepository classRepository = classRepository;

    public async Task<IEnumerable<Class>> GetAllClassesAsync()
    {
        return await classRepository.GetAllAsync();
    }

    public async Task<IEnumerable<LearningTrail>> GetAllTrailsAsync()
    {
        return await trailRepository.GetAllAsync();
    }
}