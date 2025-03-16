using Itenium.PatternHatching.Singleton;

namespace Itenium.PatternHatching.Composite;

/// <summary>
/// Handles the security for a Node
/// </summary>
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