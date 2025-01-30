using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class StudentProgressRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<StudentProgress>(contextFactory), IStudentProgressRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public async Task<StudentProgress?> GetStudentProgressForAssignmentAsync(Guid studentId, Guid assignmentId)
    {
        await using var context = contextFactory.CreateDbContext();
        return await context.StudentProgress.
            Include(sp => sp.AssignmentId).
            Include(sp => sp.Student).
            FirstOrDefaultAsync(sp => sp.StudentId == studentId && sp.AssignmentId == assignmentId);
    }
}
