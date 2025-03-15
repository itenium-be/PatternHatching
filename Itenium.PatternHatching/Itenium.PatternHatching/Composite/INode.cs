using Itenium.PatternHatching.Visitor;

namespace Itenium.PatternHatching.Composite
{
    /// <summary>
    /// COMPOSITE:
    /// The interface implemented by both
    /// the individual objects (Leafs=Files) and
    /// compositions (Branches=Directories)
    /// </summary>
    public interface INode
    {
        IEnumerable<INode> Children { get; }
        bool Adopt(INode node);
        bool Orphan(INode node);
        StreamReader GetReader();

        #region Visitor
        T Accept<T>(IVisitor<T> visitor);
        #endregion
    }
}
