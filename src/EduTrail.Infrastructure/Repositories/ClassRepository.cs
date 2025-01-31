using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class ClassRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<Class>(contextFactory), IClassRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<IEnumerable<Class>> GetClassesWithStudentsByTeacherIdAsync(Guid teacherId)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Classes.Where(c => c.TeacherId == teacherId)
            .Include(c => c.Students).ToListAsync();
    }
}
