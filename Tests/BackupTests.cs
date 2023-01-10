using EnvBackupRestore.Domain;
using Moq;

namespace Tests;

public class BackupTests
{
    [Test]
    public void HappyPath()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var classUnderTest = new BackupCommand();
        
        classUnderTest.Execute();
        
        mockFileSystem.Verify(x => x.Copy());
    }
}