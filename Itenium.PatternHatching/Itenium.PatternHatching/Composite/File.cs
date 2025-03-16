using Itenium.PatternHatching.Singleton;
using Itenium.PatternHatching.Visitor;
using System.IO.Abstractions;

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
    protected override StreamReader GetReaderCore(User? user = null) => new(new MemoryStream("File Contents"u8.ToArray()));

    #region Visitor
    public override T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion

    #region Template Method
    protected internal override IFileSystemInfo Info => new FileInfoWrapper(new FileSystem(), new FileInfo(""));
    #endregion
}