using Itenium.PatternHatching.Proxy;
using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Tests.Visitor;

public class SizeVisitorTests
{
    private static readonly int DefaultFileSize = "File Contents".Length;

    [Fact]
    public void SizeFile_ReturnsContentLength()
    {
        var visitor = new SizeVisitor();
        var file = new Composite.File();
        int result = file.Accept(visitor);
        Assert.Equal(DefaultFileSize, result);
    }

    [Fact]
    public void SizeLink_ReturnsFileContentLength()
    {
        var visitor = new SizeVisitor();
        var file = new Composite.File();
        var link = new Link(file);
        int result = link.Accept(visitor);
        Assert.Equal(DefaultFileSize, result);
    }

    [Fact]
    public void SizeDirectory_ReturnsAllFilesContentLength()
    {
        var visitor = new SizeVisitor();
        var dir = new Composite.Directory();
        var file1 = new Composite.File();
        var file2 = new Composite.File();
        dir.Adopt(file1);
        dir.Adopt(file2);
        var link = new Link(dir);

        int result = link.Accept(visitor);
        Assert.Equal(DefaultFileSize * 2, result);
    }
}