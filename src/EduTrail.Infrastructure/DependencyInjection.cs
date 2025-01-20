using EduTrail.Application.Configuration;
using EduTrail.Application.Interfaces;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using EduTrail.Infrastructure.Identity;
using EduTrail.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduTrail.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
            //options.UseSqlServer(connectionString));

        // Register Identity
        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });

        services.Configure<FileStorageOptions>(configuration.GetSection("FileStorage"));

        // Register repositories
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<ILearningTrailRepository, LearningTrailRepository>();
        services.AddScoped<IModuleContentRepository, ModuleContentRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITrailModuleRepository, TrailModuleRepository>();
        services.AddScoped<IAssignmentSubmissionRepository, AssignmentSubmissionRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IClassStudentRepository, ClassStudentRepository>();
        services.AddScoped<IClassTrailRepository, ClassTrailRepository>();
        services.AddScoped<IStudentProgressRepository, StudentProgressRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        // Infra
        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        return services;
    }
}
