using EduTrail.Application.Configuration;
using EduTrail.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EduTrail.Infrastructure.Services;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string basePath;
    private readonly ILogger<LocalFileStorageService> logger;

    public LocalFileStorageService(ILogger<LocalFileStorageService> logger, IOptions<FileStorageOptions> options)
    {
        basePath = Path.GetFullPath(options.Value.BasePath);
        this.logger = logger;
        Directory.CreateDirectory(basePath);

        logger.LogInformation("Writing uploaded files to {FileStoragePath}", basePath);
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        var relativePath = Path.Combine(
            DateTime.UtcNow.ToString("yyyy-MM-dd"),
            $"{Guid.NewGuid()}-{fileName}");

        var fullPath = Path.Combine(basePath, relativePath);
        var fullPathDir = Path.GetDirectoryName(fullPath);
        if (string.IsNullOrEmpty(fullPathDir))
        {
            logger.LogError("Invalid file path: {Path}", fullPath);
            throw new InvalidOperationException("Invalid file path");
        }
        Directory.CreateDirectory(fullPathDir);

        await using var fileStream2 = File.Create(fullPath);
        await fileStream.CopyToAsync(fileStream2);

        return relativePath;
    }

    public Task DeleteFileAsync(string path)
    {
        var fullPath = Path.Combine(basePath, path);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        return Task.CompletedTask;
    }

    public Task<Stream> DownloadFileAsync(string path)
    {
        var fullPath = Path.Combine(basePath, path);
        return Task.FromResult<Stream>(File.OpenRead(fullPath));
    }

    public Task<string> GetPublicUrlAsync(string path, TimeSpan? expiry = null)
    {
        // For local storage, we'll return a relative URL
        return Task.FromResult($"/api/files/{path}");
    }
}
