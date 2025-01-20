using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class ModuleContentRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<ModuleContent>(contextFactory), IModuleContentRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<IEnumerable<ModuleContent>> GetContentsByAssignmentAsync(Guid assignmentId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.ModuleContents
            .Where(mc => mc.AssignmentId == assignmentId)
            .OrderBy(mc => mc.OrderIndex)
            .ToListAsync();
    }
}
