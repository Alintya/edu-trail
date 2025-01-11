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
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        // Register repositories
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<ILearningTrailRepository, LearningTrailRepository>();
        services.AddScoped<IModuleContentRepository, ModuleContentRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITrailModuleRepository, TrailModuleRepository>();

        // Infra
        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        return services;
    }
}
