namespace EduTrail.Domain.Entities;

public class FileUpload
{
    public Guid Id { get; private set; }
    public string StorageIdentifier { get; private set; }
    public string ContentType { get; private set; }
    public long Size { get; private set; }
    public DateTime UploadedAt { get; private set; }
    public string UploadedBy { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;

    private FileUpload() { } // For EF Core

    public FileUpload(string storageId, string contentType, long size)
    {
        //Id = Guid.NewGuid();
        StorageIdentifier = storageId;
        ContentType = contentType;
        Size = size;
        UploadedAt = DateTime.UtcNow;
    }
}
