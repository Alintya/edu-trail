using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class ClassTrailRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<ClassTrail>(contextFactory), IClassTrailRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;
}
