using Itenium.PatternHatching.Proxy;

namespace Itenium.PatternHatching.Visitor;

/// <summary>
/// VISITOR:
/// Add arbitrary functionality to the COMPOSITE
/// in an Open/Closed way.
/// </summary>
public interface IVisitor<out T>
{
    T Visit(Composite.File file);
    T Visit(Composite.Directory directory);
    T Visit(Link link);
}