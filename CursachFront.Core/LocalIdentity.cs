using CursachFront.Core.Models;
using CursachFront.Core.Models.Enums;

namespace CursachFront.Core;

public static class LocalIdentity
{
    private static bool _authorized;
    private static bool _isInRole;
    private static AppUser _user = null;

    public static bool Authorized
    {
        get { return _user is not null; }
    }
    
    public static bool IsInRole
    {
        get { return Roles.GetRoles().Any(prp => prp.Equals(_user.Role));; }
    }
    
    public static AppUser User
    {
        set { AuthorizeUser(value); }
    }
    
    private static bool AuthorizeUser(AppUser user)
    {
        if(_user is not null)
            return false;

        _user = user;
        return true;
    }

    public static ProfileData GetProfile()
    {
        if (_user is null)
            throw new Exception();

        return new()
        {
            FullName = _user.FirstName
        };
    }
}