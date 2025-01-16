using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class AssignmentSubmissionRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : Repository<AssignmentSubmission>(contextFactory), IAssignmentSubmissionRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;
}
