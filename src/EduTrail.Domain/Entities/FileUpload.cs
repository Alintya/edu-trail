namespace EduTrail.Domain.Entities;

public class FileUpload
{
    public Guid Id { get; private set; }
    public string FileName { get; private set; }
    public string ContentType { get; private set; }
    public long Size { get; private set; }
    public string Path { get; private set; }
    public DateTime UploadedAt { get; private set; }
    public string UploadedBy { get; set; } = string.Empty;

    private FileUpload() { } // For EF Core

    public FileUpload(string fileName, string contentType, long size, string path)
    {
        Id = Guid.NewGuid();
        FileName = fileName;
        ContentType = contentType;
        Size = size;
        Path = path;
        UploadedAt = DateTime.UtcNow;
    }
}
