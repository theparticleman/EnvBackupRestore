using EnvBackupRestore.Domain;
using Moq;

namespace EnvBackupRestore.Tests;

public class BackupTests
{
    [Test]
    public void HappyPath()
    {
        var now = new DateTime(2023, 1, 9, 20, 23, 42);
        var mockTime = new Mock<ITime>();
        mockTime.Setup(x => x.Now).Returns(now);
        var mockFileSystem = new Mock<IFileSystem>();
        mockFileSystem.Setup(x => x.GetFileName("file/to/back/up/file.txt")).Returns("file.txt");
        mockFileSystem.Setup(x => x.CombinePath("backup/directory", "2023-01-09 20-23-42")).Returns("timestamped/path");
        mockFileSystem.Setup(x => x.CombinePath("timestamped/path", "file.txt")).Returns("full/destination/path");
        mockFileSystem.Setup(x => x.CombinePath("backup/directory", "file.txt")).Returns("combined/path");
        var settings = new Settings
        {
            BackupDirectory = "backup/directory",
            FilesToBackUp = new List<string> { "file/to/back/up/file.txt" }
        };
        var classUnderTest = new BackupCommand(settings, mockFileSystem.Object, mockTime.Object);

        classUnderTest.Execute();

        mockFileSystem.Verify(x => x.Copy("file/to/back/up/file.txt", "full/destination/path"));
        mockFileSystem.Verify(x => x.CreateDirectory("timestamped/path"));
    }

    [Test]
    public void BackUpAllFiles()
    {
        var mockTime = new Mock<ITime>();
        var mockFileSystem = new Mock<IFileSystem>();
        var settings = new Settings
        {
            FilesToBackUp = new List<string> { "file1.txt", "file2.txt" }
        };

        var classUnderTest = new BackupCommand(settings, mockFileSystem.Object, mockTime.Object);

        classUnderTest.Execute();

        mockFileSystem.Verify(x => x.Copy(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        mockFileSystem.Verify(x => x.CreateDirectory(It.IsAny<string>()), Times.Once);
    }
}