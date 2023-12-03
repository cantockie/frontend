using CursachFront.Core.Models;
using CursachFront.Core.Models.Enums;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace CursachFront.Core;

public static class LocalIdentity
{
    private static bool _authorized;
    private static bool _isInRole;
    private static AppUser _user  = null;
    public static AppUser _userInCabinet  = _user;

    public static bool Authorized
    {
        get { return _user is not null; }
    }
    
    public static bool IsInRole(string role)
    {
         //return Roles.GetRoles().Any(prp => prp.Equals(_user.Role));; 
         return _user.Role == role;
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
        {
            return new()
            {
                FirstName = "guest",
                LastName = " ",
                Role = "GUEST",
                Education = " ",
                Country = " ",
                Rank = " ",
                ProfileImage = "face1.jpg",
                Gender = "undefined",
                BirthDay = DateTime.MinValue,
                Departments = "",
                Email = "",
                Specifications = "",
                Bio = "",
                Id = 0
            };
        }
        else return new()
        {
            FirstName = _user.FirstName,
            LastName = _user.LastName,
            Role = _user.Role,
            Education = _user.Education,
            Country = _user.Country,
            Rank = _user.Rank,
            ProfileImage = _user.PhotoName,
            Gender = _user.Gender,
            BirthDay = _user.BirthDay,
            Departments = _user.Departments,
            Email = _user.Email,
            Specifications = _user.Specifications,
            Bio = _user.Bio,
            Id = _user.Id,
        };
    }
}