using EduTrail.Application.Configuration;
using EduTrail.Application.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EduTrail.Infrastructure.Services;

public class GoogleCloudStorageService : IFileStorageService
{
    private readonly ILogger<GoogleCloudStorageService> logger;
    private readonly StorageClient storageClient;
    private readonly string bucketName;
    private readonly string basePath;

    public GoogleCloudStorageService(ILogger<GoogleCloudStorageService> logger, IOptions<FileStorageOptions> options)
    {
        this.logger = logger;
        //var credential = GoogleCredential.FromFile(options.Value..CredentialsPath);
        storageClient = StorageClient.Create();
        bucketName = options.Value.BucketName;
        basePath = options.Value.BasePath;

        logger.LogInformation("Writing uploaded files to {BucketName}:{FileStoragePath}", bucketName, basePath);
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        var objectName = $"{basePath}/{DateTime.UtcNow:yyyy/MM/dd}/{Guid.NewGuid()}-{fileName}";

        var obj = await storageClient.UploadObjectAsync(
            bucketName,
            objectName,
            contentType,
            fileStream);

        return obj.Name;
    }

    public async Task DeleteFileAsync(string path)
    {
        await storageClient.DeleteObjectAsync(bucketName, path);
    }

    public async Task<Stream> DownloadFileAsync(string path)
    {
        var stream = new MemoryStream();
        await storageClient.DownloadObjectAsync(bucketName, path, stream);
        stream.Position = 0;
        return stream;
    }

    public async Task<string> GetPublicUrlAsync(string path, TimeSpan? expiry = null)
    {
        var duration = expiry ?? TimeSpan.FromHours(1);
        var urlSigner = UrlSigner.FromCredential((await GoogleCredential.GetApplicationDefaultAsync()).UnderlyingCredential as ServiceAccountCredential);

        return await urlSigner.SignAsync(bucketName, path, duration);
    }
}
