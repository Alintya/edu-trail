namespace EduTrail.Domain.Entities;

/// <summary>
/// Group of students with an assigned teacher
/// </summary>
public class Class
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid TeacherId { get; set; }

    // Navigation properties
    public Teacher Teacher { get; set; } = null!;
    public ICollection<ClassStudent> Students { get; set; } = [];
    public ICollection<ClassTrail> AssignedTrails { get; set; } = [];
}
