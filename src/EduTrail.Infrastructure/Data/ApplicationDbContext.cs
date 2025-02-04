using EduTrail.Domain.Entities;
using EduTrail.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduTrail.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<LearningTrail> LearningTrails => Set<LearningTrail>();
    public DbSet<TrailModule> TrailModules => Set<TrailModule>();
    public DbSet<AssignmentContent> AssignmentContents => Set<AssignmentContent>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<ClassStudent> ClassStudents => Set<ClassStudent>();
    public DbSet<ClassTrail> ClassTrails => Set<ClassTrail>();
    public DbSet<StudentProgress> StudentProgress => Set<StudentProgress>();
    public DbSet<FileUpload> FileUploads => Set<FileUpload>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserProfileConfiguration());
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new TeacherConfiguration());
        builder.ApplyConfiguration(new LearningTrailConfiguration());
        builder.ApplyConfiguration(new TrailModuleConfiguration());
        builder.ApplyConfiguration(new AssignmentContentConfiguration());
        builder.ApplyConfiguration(new AssignmentConfiguration());
        builder.ApplyConfiguration(new AssignmentSubmissionConfiguration());
        builder.ApplyConfiguration(new ClassConfiguration());
        builder.ApplyConfiguration(new ClassStudentConfiguration());
        builder.ApplyConfiguration(new ClassTrailConfiguration());
        builder.ApplyConfiguration(new StudentProgressConfiguration());
        builder.ApplyConfiguration(new FileUploadConfiguration());
    }
}

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.UseTpcMappingStrategy(); // Table-per-concrete-type inheritance

        builder.Property(p => p.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();
    }
}

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.StudentNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(s => s.EnrollmentDate)
            .IsRequired();
    }
}

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(t => t.Department)
            .HasMaxLength(100);

        builder.Property(t => t.Title)
            .HasMaxLength(50);
    }
}

public class LearningTrailConfiguration : IEntityTypeConfiguration<LearningTrail>
{
    public void Configure(EntityTypeBuilder<LearningTrail> builder)
    {
        builder.Property(lt => lt.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(lt => lt.Description)
            .HasMaxLength(1000);

        builder.Property(lt => lt.CreatedBy)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(lt => lt.Modules)
            .WithOne(m => m.LearningTrail)
            .HasForeignKey(m => m.LearningTrailId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class TrailModuleConfiguration : IEntityTypeConfiguration<TrailModule>
{
    public void Configure(EntityTypeBuilder<TrailModule> builder)
    {
        builder.Property(tm => tm.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(tm => tm.Description)
            .HasMaxLength(1000);

        builder.HasMany(tm => tm.Assignments)
            .WithOne(a => a.TrailModule)
            .HasForeignKey(a => a.TrailModuleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class AssignmentContentConfiguration : IEntityTypeConfiguration<AssignmentContent>
{
    public void Configure(EntityTypeBuilder<AssignmentContent> builder)
    {
        builder.Property(mc => mc.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(mc => mc.ContentType)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<AssignmentContentType>(v))
            .IsRequired();

        builder.HasOne(c => c.File)
            .WithMany(t => t.AssignmentContents)
            .HasForeignKey(c => c.FileUploadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(mc => mc.ContentUrl)
            .HasMaxLength(1000)
            .IsRequired();
    }
}

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.HasOne(c => c.Teacher)
            .WithMany(t => t.Classes)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ClassStudentConfiguration : IEntityTypeConfiguration<ClassStudent>
{
    public void Configure(EntityTypeBuilder<ClassStudent> builder)
    {
        builder.HasKey(cs => new { cs.ClassId, cs.StudentId });

        builder.HasOne(cs => cs.Class)
            .WithMany(c => c.Students)
            .HasForeignKey(cs => cs.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.Student)
            .WithMany(s => s.EnrolledClasses)
            .HasForeignKey(cs => cs.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ClassTrailConfiguration : IEntityTypeConfiguration<ClassTrail>
{
    public void Configure(EntityTypeBuilder<ClassTrail> builder)
    {
        builder.HasKey(ct => new { ct.ClassId, ct.LearningTrailId });

        builder.HasOne(ct => ct.Class)
            .WithMany(c => c.AssignedTrails)
            .HasForeignKey(ct => ct.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ct => ct.LearningTrail)
            .WithMany(lt => lt.ClassTrails)
            .HasForeignKey(ct => ct.LearningTrailId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.Property(a => a.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Description)
            .HasMaxLength(1000);

        builder.HasMany(tm => tm.Contents)
            .WithOne(c => c.Assignment)
            .HasForeignKey(c => c.AssignmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.Tags)
            .HasConversion(
                tags => string.Join(',', tags), // Convert List<string> to string
                tags => tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(), // Convert string back to List<string>
                new ValueComparer<List<string>>(
                    (v1, v2) => v1!.SequenceEqual(v2!),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList())
        );
    }
}

public class AssignmentSubmissionConfiguration : IEntityTypeConfiguration<AssignmentSubmission>
{
    public void Configure(EntityTypeBuilder<AssignmentSubmission> builder)
    {
        builder.Property(a => a.SubmissionUrl)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(a => a.Feedback)
            .HasMaxLength(1000);

        builder.HasOne(a => a.Student)
            .WithMany(s => s.Submissions)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class StudentProgressConfiguration : IEntityTypeConfiguration<StudentProgress>
{
    public void Configure(EntityTypeBuilder<StudentProgress> builder)
    {
        builder.HasKey(sp => new { sp.StudentId, sp.AssignmentId });

        builder.HasOne(sp => sp.Student)
            .WithMany(s => s.Progress)
            .HasForeignKey(sp => sp.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sp => sp.Assignment)
            .WithMany(a => a.Progress)
            .HasForeignKey(sp => sp.AssignmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class FileUploadConfiguration : IEntityTypeConfiguration<FileUpload>
{
    public void Configure(EntityTypeBuilder<FileUpload> builder)
    {
        builder.ToTable("FileUploads");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StorageIdentifier)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.ContentType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Size)
            .IsRequired();

        builder.Property(x => x.UploadedBy)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.UploadedAt)
            .IsRequired();

        // Indexes
        builder.HasIndex(x => x.UploadedAt);
        builder.HasIndex(x => x.UploadedBy);
    }
}
