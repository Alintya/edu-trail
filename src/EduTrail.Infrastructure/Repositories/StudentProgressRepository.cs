using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class StudentProgressRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<StudentProgress>(contextFactory), IStudentProgressRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;
}
