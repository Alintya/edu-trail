using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class ClassStudentRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<ClassStudent>(contextFactory), IClassStudentRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;
}
