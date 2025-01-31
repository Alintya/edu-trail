using EduTrail.Domain.Entities;

namespace EduTrail.Application.Interfaces;

public interface IFileManagementAppService
{
    Task<FileUpload> UploadFileAsync(Stream fileStream, string fileName, string contentType, long size);
    Task<Stream> DownloadFileAsync(Guid fileUploadId);
    Task<string> GetUri(Guid fileUploadId);
}
