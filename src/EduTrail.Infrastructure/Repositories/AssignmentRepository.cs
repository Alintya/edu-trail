using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class AssignmentRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<Assignment>(contextFactory), IAssignmentRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<Assignment?> GetAssignmentWithContentsAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Assignments
            .Include(a => a.Contents)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Assignment?> GetAssignmentWithSubmissionsAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Assignments
            .Include(a => a.Submissions)
                .ThenInclude(s => s.Student)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Assignment>> GetAssignmentsByModuleAsync(Guid moduleId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Assignments
            .Where(a => a.TrailModuleId == moduleId)
            .OrderBy(a => a.DueDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Assignment>> GetPendingAssignmentsByStudentAsync(Guid studentId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Assignments
            .Where(a => !a.Submissions.Any(s => s.StudentId == studentId))
            .OrderBy(a => a.DueDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Assignment>> GetAssignmentsByTagAsync(string tag)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Assignments
            .Where(a => a.Tags.Contains(tag))
            .ToListAsync();
    }
}
