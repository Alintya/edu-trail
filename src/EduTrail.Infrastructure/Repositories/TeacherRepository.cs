using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class TeacherRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<Teacher>(contextFactory), ITeacherRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<Teacher?> GetTeacherWithClassesAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Teachers
            .Include(t => t.Classes)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Teacher?> GetTeacherWithTrailsAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Teachers
            .Include(t => t.CreatedTrails)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
