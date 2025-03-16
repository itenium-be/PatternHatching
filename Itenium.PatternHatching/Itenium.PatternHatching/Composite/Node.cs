using Itenium.PatternHatching.Visitor;
using Itenium.PatternHatching.Singleton;

namespace Itenium.PatternHatching.Composite;

/// <summary>
/// COMPOSITE:
/// The base class implemented by both
/// the individual objects (Leafs=Files) and
/// compositions (Branches=Directories)
///
/// TEMPLATE METHOD:
/// The base Node class checks security and
/// delegates the implementation details to
/// the subclasses
/// </summary>
public abstract class Node
{
    private readonly AccessControl _accessControl;

    protected Node(AccessControl? accessControl = null)
    {
        _accessControl = accessControl ?? new AccessControl(Users.User);
    }

    public abstract IEnumerable<Node> Children { get; }
    public abstract bool Adopt(Node node);
    public abstract bool Orphan(Node node);

    #region Template Method
    protected abstract StreamReader GetReaderCore(User? user = null);
    protected abstract string GetWarning(Warning type);

    public StreamReader GetReader(User? user = null)
    {
        if (!_accessControl.CanRead(user))
            throw new UnauthorizedAccessException(GetWarning(Warning.Unreadable));

        return GetReaderCore(user);
    }

    protected enum Warning
    {
        Unreadable,
        Unwritable,
        Undeletable,
    }
    #endregion

    #region Visitor
    public abstract T Accept<T>(IVisitor<T> visitor);
    #endregion
}