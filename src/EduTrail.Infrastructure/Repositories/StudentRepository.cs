using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class StudentRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<Student>(contextFactory), IStudentRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;
}
