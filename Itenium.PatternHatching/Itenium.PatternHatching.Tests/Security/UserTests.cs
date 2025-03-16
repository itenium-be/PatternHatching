using Itenium.PatternHatching.Composite;
using Itenium.PatternHatching.Proxy;
using Itenium.PatternHatching.Singleton;

namespace Itenium.PatternHatching.Tests.Security;

public class UserTests
{
    private readonly User _erich;
    private readonly User _john;

    private readonly Composite.File _erichFile;
    private readonly Composite.File _erichSharedFile;
    
    public UserTests()
    {
        _erich = Users.LogIn("Erich", "");
        _john = Users.LogIn("John", "");

        _erichFile = new Composite.File(new AccessControl(_erich));
        _erichSharedFile = new Composite.File(new AccessControl(_erich) {OtherReadable = true});
    }

    [Fact]
    public void FileOwner_CanReadFileContent()
    {
        var file = new Composite.File();
        using var result = file.GetReader();
        Assert.NotNull(result);
    }

    [Fact]
    public void FileOwner_WithUserProvided_CanReadFileContent()
    {
        using var result = _erichFile.GetReader(_erich);
        Assert.NotNull(result);
    }

    [Fact]
    public void OtherUser_ReadingFileContent_Throws()
    {
        Assert.Throws<UnauthorizedAccessException>(() => _erichFile.GetReader(_john));
    }

    [Fact]
    public void OtherUser_ReadingFileContent_WorksWhenOtherReadable()
    {
        using var result = _erichSharedFile.GetReader(_john);
        Assert.NotNull(result);
    }

    [Fact]
    public void LinkOwner_CanReadOwnFileContent()
    {
        Assert.NotSame(_erich, Users.User);

        var link = new Link(_erichFile, new AccessControl(_erich));
        using var result = link.GetReader(_erich);
        Assert.NotNull(result);
    }

    [Fact]
    public void LinkOwner_ReadingOtherFile_Throws()
    {
        var link = new Link(_erichFile, new AccessControl(_john));
        Assert.Throws<UnauthorizedAccessException>(() => link.GetReader(_john));
    }

    [Fact]
    public void LinkOwner_CanReadOtherReadableFile()
    {
        var link = new Link(_erichSharedFile, new AccessControl(_john));
        using var result = link.GetReader(_john);
        Assert.NotNull(result);
    }
}