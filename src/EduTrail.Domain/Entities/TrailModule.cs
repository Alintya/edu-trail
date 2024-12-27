namespace EduTrail.Domain.Entities;

/// <summary>
/// Section within a learning trail
/// </summary>
public class TrailModule
{
    public Guid Id { get; set; }
    public Guid LearningTrailId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OrderIndex { get; set; }

    // Navigation properties
    public LearningTrail LearningTrail { get; set; } = null!;
    public ICollection<ModuleContent> Contents { get; set; } = [];
    public ICollection<Assignment> Assignments { get; set; } = [];
}
