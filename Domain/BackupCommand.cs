namespace EnvBackupRestore.Domain;

public class BackupCommand
{
    private readonly Settings settings;
    private readonly IFileSystem fileSystem;
    private readonly ITime time;

    public BackupCommand(Settings settings, IFileSystem fileSystem, ITime time)
    {
        this.settings = settings;
        this.fileSystem = fileSystem;
        this.time = time;
    }

    public void Execute()
    {
        var timeStampedDirectoryName = time.Now.ToString("yyyy-MM-dd HH-mm-ss");
        var backupPath = fileSystem.CombinePath(settings.BackupDirectory, timeStampedDirectoryName);
        fileSystem.CreateDirectory(backupPath);
        foreach (var fileToBackUp in settings.FilesToBackUp)
        {
            var fileName = fileSystem.GetFileName(fileToBackUp);
            var destinationPath = fileSystem.CombinePath(backupPath, fileName);
            fileSystem.Copy(fileToBackUp, destinationPath);
        }
    }
}