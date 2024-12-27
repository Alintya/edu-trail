namespace EduTrail.Domain.Entities;

public class Teacher : UserProfile
{
    public string? Department { get; set; }
    public string? Title { get; set; }

    // Navigation properties
    public ICollection<Class> Classes { get; set; } = [];
    public ICollection<LearningTrail> CreatedTrails { get; set; } = [];
}
