﻿using EduTrail.Application.Interfaces;
using EduTrail.Domain.Entities;
using EduTrail.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace EduTrail.Application.Services;

public class FileUploadService
{
    private readonly ILogger<FileUploadService> logger;
    private readonly IFileUploadRepository fileUploadRepository;
    private readonly IFileStorageService fileStorageService;

    public FileUploadService(ILogger<FileUploadService> logger, IFileUploadRepository fileUploadRepository, IFileStorageServiceFactory storageServiceFactory)
    {
        this.logger = logger;
        this.fileUploadRepository = fileUploadRepository;
        fileStorageService = storageServiceFactory.CreateStorageService();
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
}
