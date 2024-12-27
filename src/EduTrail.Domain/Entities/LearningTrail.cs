namespace EduTrail.Domain.Entities;

public class LearningTrail
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
    public bool IsPublished { get; set; }

    // Navigation properties
    public ICollection<TrailModule> Modules { get; set; } = [];
    public ICollection<ClassTrail> ClassTrails { get; set; } = [];
}
