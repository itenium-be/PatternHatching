using Itenium.PatternHatching.Visitor;
using System.IO.Abstractions;
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
    protected Node(AccessControl? accessControl = null)
    {
        AccessControl = accessControl ?? new AccessControl(Users.User);
    }

    public abstract IEnumerable<Node> Children { get; }
    public abstract bool Adopt(Node node);
    public abstract bool Orphan(Node node);

    protected abstract StreamReader GetReaderCore(User? user = null);
    public StreamReader GetReader(User? user = null)
    {
        if (!AccessControl.CanRead(user))
            throw new UnauthorizedAccessException("Node unreadable");

        return GetReaderCore(user);
    }

    #region Visitor
    public abstract T Accept<T>(IVisitor<T> visitor);
    #endregion

    #region Template Method
    protected internal abstract IFileSystemInfo Info { get; }
    private AccessControl AccessControl { get; }
    //public void Delete()
    //{
    //    if (!AccessControl.Writable)
    //        throw new UnauthorizedAccessException($"{Info.FullName} is not writable");

    //    Info.Delete();
    //}
    #endregion
}

public class AccessControl
{
    public User Owner { get; set; }
    public bool OtherReadable { get; set; }

    public AccessControl(User owner)
    {
        Owner = owner;
    }

    public bool CanRead(User? user)
    {
        user ??= Users.User;
        if (user == Owner)
            return true;

        return OtherReadable;
    }

    public override string ToString() => $"Owner={Owner}, OtherReadable={OtherReadable}";
}