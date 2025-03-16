using Itenium.PatternHatching.Singleton;
using Itenium.PatternHatching.Visitor;
using System.IO.Abstractions;

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

    protected override StreamReader GetReaderCore(User? user = null) => new(Stream.Null);

    #region Visitor
    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion

    #region Template Method
    protected internal override IFileSystemInfo Info => new DirectoryInfoWrapper(new FileSystem(), new DirectoryInfo(""));
    #endregion
}