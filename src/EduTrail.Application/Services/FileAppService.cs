using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace EduTrail.Application.Services;

public class FileAppService
{
    private readonly ILogger<FileAppService> logger;
    private readonly IFileUploadRepository fileUploadRepository;
    private readonly IFileStorageService fileStorageService;

    public FileAppService(ILogger<FileAppService> logger, IFileUploadRepository fileUploadRepository, IFileStorageServiceFactory storageServiceFactory)
    {
        this.logger = logger;
        this.fileUploadRepository = fileUploadRepository;
        fileStorageService = storageServiceFactory.CreateStorageService();

        logger.LogInformation("Using {FileStorageServiceType} for storage", fileStorageService.GetType().Name);
    }

    public async Task<FileUpload> UploadFileAsync(Stream fileStream, string fileName, string contentType, long size)
    {
        var storageIdentifier = await fileStorageService.UploadFileAsync(fileStream, fileName, contentType);

        var fileUpload = new FileUpload
        {
            StorageIdentifier = storageIdentifier,
            ContentType = contentType,
            Size = size,
            DisplayName = fileName
        };

        await fileUploadRepository.AddAsync(fileUpload);

        return fileUpload;
    }

    public async Task<string> GetUri(FileUpload file)
    {
        // TODO: auth check
        return await fileStorageService.GetPublicUrlAsync(file.StorageIdentifier);
    }
}
