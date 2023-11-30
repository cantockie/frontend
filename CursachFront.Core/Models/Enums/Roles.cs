namespace CursachFront.Core.Models.Enums;

public static class Roles
{
    public static string ADMIN = nameof(ADMIN);
    public static string MANAGER = nameof(MANAGER);
    public static string USER = nameof(USER);

    public static List<string> GetRoles()
        => new List<string>() { ADMIN, MANAGER, USER };
}