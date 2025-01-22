using EduTrail.Application.Configuration;
using EduTrail.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EduTrail.Infrastructure.Services;

public class FileStorageServiceFactory : IFileStorageServiceFactory
{
    private readonly IServiceProvider serviceProvider;
    private readonly FileStorageOptions options;

    public FileStorageServiceFactory(
        IServiceProvider serviceProvider,
        IOptions<FileStorageOptions> options)
    {
        this.serviceProvider = serviceProvider;
        this.options = options.Value;
    }

    public IFileStorageService CreateStorageService()
    {
        return options.Provider switch
        {
            FileStorageProvider.LocalStorage => ActivatorUtilities.CreateInstance<LocalFileStorageService>(serviceProvider),
            //FileStorageProvider.GoogleCloudStorage => ActivatorUtilities.CreateInstance<GoogleCloudStorageService>(serviceProvider),
            _ => throw new ArgumentException($"Unsupported storage provider: {options.Provider}")
        };
    }
}
