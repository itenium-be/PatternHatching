using Itenium.PatternHatching.Proxy;
using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Tests;

public class CatVisitorTests
{
    [Fact]
    public void CatDirectory_ReturnsStaticErrorMessage()
    {
        var catVisitor = new CatVisitor();
        var dir = new Composite.Directory();
        var result = dir.Accept(catVisitor);
        Assert.Equal("Is a directory", result);
    }

    [Fact]
    public void CatFile_ReturnsContent()
    {
        var catVisitor = new CatVisitor();
        var file = new Composite.File();
        var result = file.Accept(catVisitor);
        Assert.Equal("File Contents", result);
    }

    [Fact]
    public void CatFileLink_ReturnsContent()
    {
        var catVisitor = new CatVisitor();
        var file = new Composite.File();
        var link = new Link(file);
        var result = link.Accept(catVisitor);
        Assert.Equal("File Contents", result);
    }

    [Fact]
    public void CatDoubleFileLink_ReturnsContent()
    {
        var catVisitor = new CatVisitor();
        var file = new Composite.File();
        var link = new Link(file);
        var link2 = new Link(link);
        var result = link2.Accept(catVisitor);
        Assert.Equal("File Contents", result);
    }

    [Fact]
    public void CatDirectoryLink_ReturnsReturnsStaticErrorMessage()
    {
        var catVisitor = new CatVisitor();
        var dir = new Composite.Directory();
        var link = new Link(dir);
        var result = link.Accept(catVisitor);
        Assert.Equal("Is a directory", result);
    }
}