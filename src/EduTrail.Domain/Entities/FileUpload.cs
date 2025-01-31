namespace EduTrail.Domain.Entities;

public class FileUpload
{
    public Guid Id { get; private set; }
    public required string StorageIdentifier { get; init; }
    public required string ContentType { get; init; }
    public long Size { get; init; }
    public DateTime UploadedAt { get; private set; }
    public string UploadedBy { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<AssignmentContent> AssignmentContents { get; set; } = [];

    public FileUpload()
    {
        UploadedAt = DateTime.UtcNow;
    }
}
