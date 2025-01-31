using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;

namespace EduTrail.Application.Services;

public class TrailAppService(ILearningTrailRepository trailRepository, IModuleContentRepository moduleContentRepository, IFileManagementAppService fileManagementService) : ITrailAppService
{
    private readonly ILearningTrailRepository trailRepository = trailRepository;
    private readonly IModuleContentRepository moduleContentRepository = moduleContentRepository;
    private readonly IFileManagementAppService fileManagementService = fileManagementService;

    public async Task<LearningTrail?> GetTrailByIdAsync(Guid id)
    {
        return await trailRepository.GetTrailWithModulesAsync(id);
    }

    public async Task<Stream> OpenAssignmentContentAsync(Guid assignmentContentId)
    {
        throw new NotImplementedException();
        var assignmentContent = await moduleContentRepository.GetByIdAsync(assignmentContentId);        
        // return await fileManagementService.DownloadFileAsync(assignmentContent.FileUploadId);
    }
}
