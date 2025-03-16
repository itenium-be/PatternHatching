using Itenium.PatternHatching.Singleton;
using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Composite;

/// <summary>
/// Composite Branch
/// </summary>
public class Directory : Node
{
    private readonly List<Node> _nodes = [];

    public Directory(AccessControl? accessControl = null) : base(accessControl) { }

    public override IEnumerable<Node> Children => _nodes;
    public override bool Adopt(Node node)
    {
        _nodes.Add(node);
        return true;
    }

    public override bool Orphan(Node node)
    {
        return _nodes.Remove(node);
    }

    #region Template Method
    protected override StreamReader GetReaderCore(User? user = null) => new(Stream.Null);
    protected override string GetWarning(Warning type)
    {
        return $"Directory is {type}";
    }
    #endregion

    #region Visitor
    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion
}