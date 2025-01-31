namespace EduTrail.Domain.Entities;

/// <summary>
/// documents, videos, links
/// </summary>
public class AssignmentContent
{
    public Guid Id { get; set; }
    public Guid AssignmentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public AssignmentContentType ContentType { get; set; } = AssignmentContentType.None; // Document, Video, Link, etc.
    public string ContentUrl { get; set; } = string.Empty;
    public Guid? FileUploadId { get; set; }
    public int OrderIndex { get; set; }

    // Navigation properties
    public Assignment Assignment { get; set; } = null!;
    public FileUpload? File { get; set; }
}

public enum AssignmentContentType
{
    None = 0,
    Text = 1,
    Pdf = 2,
    Link = 3,
    File = 4,
    Video = 5,
}
