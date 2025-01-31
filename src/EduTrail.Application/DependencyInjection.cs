using EduTrail.Application.Interfaces;
using EduTrail.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EduTrail.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        // Register application services
        //services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IFileManagementAppService, FileManagementAppService>();
        services.AddScoped<ITrailAppService, TrailAppService>();
        services.AddScoped<IStudentAppService, StudentAppService>();
        services.AddScoped<ITeacherAppService, TeacherAppService>();

        return services;
    }
}
