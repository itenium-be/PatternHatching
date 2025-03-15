using Itenium.PatternHatching.Proxy;
using Directory = Itenium.PatternHatching.Composite.Directory;
using File = Itenium.PatternHatching.Composite.File;

namespace Itenium.PatternHatching.Visitor;

/// <summary>
/// "cat": Print the content of a file
/// </summary>
public class CatVisitor : IVisitor<string>
{
    public string Visit(File file)
    {
        using var reader = file.GetReader();
        return reader.ReadToEnd();
    }

    public string Visit(Directory directory)
    {
        return "Is a directory";
    }

    public string Visit(Link link)
    {
        return link.Subject.Accept(this);
    }
}