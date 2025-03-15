using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Composite;

/// <summary>
/// Composite Branch
/// </summary>
public class Directory : INode
{
    private readonly List<INode> _nodes = [];

    public IEnumerable<INode> Children => _nodes;
    public bool Adopt(INode node)
    {
        _nodes.Add(node);
        return true;
    }

    public bool Orphan(INode node)
    {
        return _nodes.Remove(node);
    }

    public StreamReader GetReader() => new(Stream.Null);

    #region Visitor
    public T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion
}