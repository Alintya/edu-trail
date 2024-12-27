namespace EduTrail.Domain.Entities;

public class ClassTrail
{
    public Guid ClassId { get; set; }
    public Guid LearningTrailId { get; set; }
    public DateTime AssignedAt { get; set; }
    public DateTime? DueDate { get; set; }

    public Class Class { get; set; } = null!;
    public LearningTrail LearningTrail { get; set; } = null!;
}
