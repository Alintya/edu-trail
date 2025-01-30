using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace EduTrail.Application.Services;

public class FileManagementAppService(ILogger<FileManagementAppService> logger, IFileUploadRepository fileUploadRepository, IFileStorageServiceFactory storageServiceFactory) : IFileManagementAppService
{
    private readonly ILogger<FileManagementAppService> logger = logger;
    private readonly IFileUploadRepository fileUploadRepository = fileUploadRepository;
    private readonly IFileStorageService fileStorageService = storageServiceFactory.CreateStorageService();

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

    public async Task<Stream> DownloadFileAsync(Guid fileUploadId)
    {
        var fileUpload = await fileUploadRepository.GetByIdAsync(fileUploadId);

        if (fileUpload == null)
        {
            logger.LogError("File not found with ID {FileUploadId}", fileUploadId);
            throw new FileNotFoundException();
        }

        return await fileStorageService.DownloadFileAsync(fileUpload.StorageIdentifier);
    }

    public async Task<string> GetUri(Guid fileUploadId)
    {
        var fileUpload = await fileUploadRepository.GetByIdAsync(fileUploadId);

        // TODO: auth check
        return await fileStorageService.GetPublicUrlAsync(fileUpload.StorageIdentifier);
    }
}
