using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class LearningTrailRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<LearningTrail>(contextFactory), ILearningTrailRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<LearningTrail?> GetTrailWithModulesAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.LearningTrails
            .Include(lt => lt.Modules)
                .ThenInclude(m => m.Assignments)
            .FirstOrDefaultAsync(lt => lt.Id == id);
    }

    public async Task<IEnumerable<LearningTrail>> GetTrailsByTeacherAsync(Guid teacherId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.LearningTrails
            .Where(lt => lt.CreatedBy == teacherId.ToString())
            .ToListAsync();
    }
}
