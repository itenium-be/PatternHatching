namespace Itenium.PatternHatching.Singleton;

public sealed class User
{
    public string Name { get; }
    internal string Password { get; }

    internal User(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public override string ToString() => Name;
}

public static class Users
{
    private static readonly User AnonymousUser = new("Anonymous", "");
    private static readonly List<User> UserRepository = [
        new("Erich", ""),
        new("Richard", ""),
        new("Ralph", ""),
        new("John", ""),
    ];

    public static User User { get; private set; } = AnonymousUser;

    public static User LogIn(string userName, string password)
    {
        var user = UserRepository
            .Where(x => x.Name == userName)
            .SingleOrDefault(x => x.Password == password);

        if (user == null)
            throw new UnauthorizedAccessException("Log-in invalid!");

        User = user;
        return user;
    }
}