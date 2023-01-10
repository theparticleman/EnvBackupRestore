using EnvBackupRestore.Domain;
using Moq;

namespace EnvBackupRestore.Tests;

public class RestoreTests
{
    [Test]
    public void HappyPath()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        mockFileSystem.Setup(x => x.ListDirectories("backup/directory"))
            .Returns(new List<string> { "backup/directory/backup0", "backup/directory/backup1" });
        mockFileSystem.Setup(x => x.GetFileName("path/file1.txt")).Returns("file1.txt");
        mockFileSystem.Setup(x => x.GetFileName("path/file2.txt")).Returns("file2.txt");
        mockFileSystem.Setup(x => x.CombinePath("backup/directory/backup1", "file1.txt"))
            .Returns("backup/directory/backup1/file1.txt");
        mockFileSystem.Setup(x => x.CombinePath("backup/directory/backup1", "file2.txt"))
            .Returns("backup/directory/backup1/file2.txt");
        var settings = new Settings
        {
            BackupDirectory = "backup/directory",
            FilesToBackUp = new List<string> { "path/file1.txt", "path/file2.txt" }
        };
        var classUnderTest = new RestoreCommand(settings, mockFileSystem.Object);

        classUnderTest.Execute();

        mockFileSystem.Verify(x => x.Copy("backup/directory/backup1/file1.txt", "path/file1.txt"));
        mockFileSystem.Verify(x => x.Copy("backup/directory/backup1/file2.txt", "path/file2.txt"));
    }
}