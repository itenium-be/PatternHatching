using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Composite;

/// <summary>
/// Composite Leaf
/// </summary>
public class File : INode
{
    public IEnumerable<INode> Children => [];
    public bool Adopt(INode node) => false;
    public bool Orphan(INode node) => false;
    public StreamReader GetReader() => new(new MemoryStream("File Contents"u8.ToArray()));

    #region Visitor
    public T Accept<T>(IVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
    #endregion
}