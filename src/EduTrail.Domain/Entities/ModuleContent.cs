namespace EduTrail.Domain.Entities;

/// <summary>
/// documents, videos, links
/// </summary>
public class ModuleContent
{
    public Guid Id { get; set; }
    public Guid TrailModuleId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty; // Document, Video, Link, etc.
    public string ContentUrl { get; set; } = string.Empty;
    public int OrderIndex { get; set; }

    // Navigation properties
    public TrailModule TrailModule { get; set; } = null!;
}
