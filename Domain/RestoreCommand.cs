namespace EnvBackupRestore.Domain;

public class RestoreCommand
{
    private readonly Settings settings;
    private IFileSystem fileSystem;

    public RestoreCommand(Settings settings, IFileSystem fileSystem)
    {
        this.settings = settings;
        this.fileSystem = fileSystem;
    }

    public void Execute()
    {
        var backupPath = fileSystem.ListDirectories(settings.BackupDirectory)
            .OrderByDescending(x => x).First();
        foreach (var fileToRestore in settings.FilesToBackUp)
        {
            var fileName = fileSystem.GetFileName(fileToRestore);
            var restorePath = fileSystem.CombinePath(backupPath, fileName);
            fileSystem.Copy(restorePath, fileToRestore);
        }
    }
}
