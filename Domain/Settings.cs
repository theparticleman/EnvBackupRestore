namespace EnvBackupRestore.Domain;

public class Settings
{
    public string BackupDirectory { get; set; }
    public List<string> FilesToBackUp { get; set; }
}