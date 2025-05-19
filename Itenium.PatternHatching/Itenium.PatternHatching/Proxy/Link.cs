using Itenium.PatternHatching.Composite;
using Itenium.PatternHatching.Singleton;
using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Proxy;

/// <summary>
/// PROXY:
/// Symbolic Link to a File or Directory
/// </summary>
public class Link : Node
{
    public Link(Node subject, AccessControl? accessControl = null) : base(accessControl)
    {
        Subject = subject;
    }

    public Node Subject { get; }

    public override IEnumerable<Node> Children => Subject.Children;
    public override bool Adopt(Node node) => Subject.Adopt(node);
    public override bool Orphan(Node node) => Subject.Orphan(node);

    #region Template Method
    protected override StreamReader GetReaderCore(User? user = null) => Subject.GetReader(user);
    protected override string GetWarning(Warning type)
    {
        return $"Link is {type}";
    }
    #endregion

    #region Visitor
    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion
}