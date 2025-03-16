using Itenium.PatternHatching.Singleton;
using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Composite;

/// <summary>
/// Composite Leaf
/// </summary>
public class File : Node
{
    public File(AccessControl? accessControl = null) : base(accessControl) { }

    public override IEnumerable<Node> Children => [];
    public override bool Adopt(Node node) => false;
    public override bool Orphan(Node node) => false;

    #region Template Method
    protected override StreamReader GetReaderCore(User? user = null) => new(new MemoryStream("File Contents"u8.ToArray()));
    protected override string GetWarning(Warning type)
    {
        return $"File is {type}";
    }
    #endregion

    #region Visitor
    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion
}