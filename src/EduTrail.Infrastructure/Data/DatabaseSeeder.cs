using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EduTrail.Infrastructure.Data;

public class DatabaseSeeder
{
    private readonly IServiceProvider serviceProvider;
    private readonly IConfiguration configuration;
    private readonly IHostEnvironment environment;

    public DatabaseSeeder(IServiceProvider sProvider, IConfiguration config)
    {
        serviceProvider = sProvider;
        configuration = config;
        environment = serviceProvider.GetRequiredService<IHostEnvironment>();
    }

    public async Task SeedAsync()
    {
        using var scope = serviceProvider.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var parallelTasks = new List<Task>();

        if (environment.IsDevelopment())
        {
            parallelTasks.Add(SeedDataAsync(scopedServices));
        }

        await SeedRolesAsync(scopedServices);
        await SeedUsersAsync(scopedServices);

        Task.WaitAll([.. parallelTasks]);
    }

    private async Task SeedUsersAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var defaultAdminConfig = configuration.GetSection("DefaultAdminUser").Get<DefaultAdminUserConfig>();

        if (defaultAdminConfig is null)
        {
            // TODO: Log error
            return;
        }
        //var adminUser = await userManager.FindByEmailAsync(defaultAdminConfig.Email);

        if (!userManager.Users.Any())
        {
            var newAdmin = new ApplicationUser { UserName = defaultAdminConfig.Email, Email = defaultAdminConfig.Email };
            await userManager.CreateAsync(newAdmin, defaultAdminConfig.Password);
            await userManager.AddToRoleAsync(newAdmin, "Admin");
        }
    }

    private async Task SeedRolesAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

        var roles = new[] { "Admin", "Teacher", "Student" };

        foreach (var role in roles)
        {
            // Check if role exists, if not, create it
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new ApplicationRole(role));
            }
        }
    }

    private async Task SeedDataAsync(IServiceProvider services)
    {
        var learningTrailRepository = services.GetRequiredService<ILearningTrailRepository>();

        if (!(await learningTrailRepository.GetAllAsync()).Any())
        {
            await learningTrailRepository.AddAsync(new LearningTrail
            {
                Title = "Introduction to Programming",
                Description = "Learn the basics of programming.",
                CreatedAt = DateTime.UtcNow,
                IsPublished = true
            });
        }
    }

    public class DefaultAdminUserConfig
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
