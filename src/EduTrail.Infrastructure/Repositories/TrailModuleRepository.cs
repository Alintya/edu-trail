using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class TrailModuleRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<TrailModule>(contextFactory), ITrailModuleRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<TrailModule?> GetModuleWithAssignmentsAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.TrailModules
            .Include(tm => tm.Assignments)
            .FirstOrDefaultAsync(tm => tm.Id == id);
    }

    public async Task<IEnumerable<TrailModule>> GetModulesByTrailAsync(Guid trailId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.TrailModules
            .Where(tm => tm.LearningTrailId == trailId)
            .OrderBy(tm => tm.OrderIndex)
            .ToListAsync();
    }
}
