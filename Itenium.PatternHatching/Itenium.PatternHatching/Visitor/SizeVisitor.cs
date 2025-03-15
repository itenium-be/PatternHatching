using Itenium.PatternHatching.Proxy;
using Directory = Itenium.PatternHatching.Composite.Directory;
using File = Itenium.PatternHatching.Composite.File;

namespace Itenium.PatternHatching.Visitor;

/// <summary>
/// Calculate the size of the files
/// </summary>
public class SizeVisitor : IVisitor<int>
{
    public int Visit(File file)
    {
        using var reader = file.GetReader();
        return reader.ReadToEnd().Length;
    }

    public int Visit(Directory directory)
    {
        return directory.Children
            .Select(child => child.Accept(this))
            .Sum();
    }

    public int Visit(Link link)
    {
        return link.Subject.Accept(this);
    }
}