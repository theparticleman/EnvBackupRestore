namespace EnvBackupRestore.Domain;

public interface IFileSystem
{
    string CombinePath(string path1, string path2);
    void Copy(string sourceFilePath, string destinationFilePath);
    string GetFileName(string fullFilePath);
    void CreateDirectory(string path);
    List<string> ListDirectories(string path);
}

public class FileSystem : IFileSystem
{
    public string CombinePath(string path1, string path2) 
      => Path.Combine(path1, path2);

    public void Copy(string sourceFilePath, string destinationFilePath) 
      => File.Copy(sourceFilePath, destinationFilePath, true);

    public void CreateDirectory(string path) 
      => Directory.CreateDirectory(path);

    public string GetFileName(string fullFilePath) 
      => Path.GetFileName(fullFilePath);

    public List<string> ListDirectories(string path) 
      => Directory.EnumerateDirectories(path).ToList();
}