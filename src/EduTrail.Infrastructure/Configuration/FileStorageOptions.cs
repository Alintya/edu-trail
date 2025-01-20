namespace EduTrail.Application.Configuration;

public class FileStorageOptions
{
    public FileStorageProvider Provider { get; set; } = FileStorageProvider.LocalStorage;
    public string BucketName { get; set; } = string.Empty;
    public string BasePath { get; set; } = "uploads";
}
