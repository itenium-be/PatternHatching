using Itenium.PatternHatching.Composite;
using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Proxy;

/// <summary>
/// PROXY:
/// Symbolic Link to a File or Directory
/// </summary>
public class Link(INode subject) : INode
{
    public INode Subject => subject;

    public IEnumerable<INode> Children => subject.Children;
    public bool Adopt(INode node) => subject.Adopt(node);
    public bool Orphan(INode node) => subject.Orphan(node);
    public StreamReader GetReader() => subject.GetReader();

    #region Visitor
    public T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion
}