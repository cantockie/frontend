using CursachFront.Core.Models;
using Newtonsoft.Json;

namespace CursachFront.Core;

public class CursachConfiguration
{
    private static string fileName = "localDb";
    public List<AppUser> AppUsers = new();
    public List<Prisoner> Prisoners = new();
    
    public static CursachConfiguration LoadFromFile()
    {
        try
        {
            return JsonConvert.DeserializeObject<CursachConfiguration>(File.ReadAllText(fileName));
        }
        catch(Exception ex)
        {
            return new CursachConfiguration();
        }
    }

    public void LoadData()
    {
        LocalDb.Prisoners = Prisoners;
        LocalDb.Users = AppUsers.Count == 0
            ? new List<AppUser>()
            {
                new()
                {
                    Username = "admin@gmail.com",
                    HashedPassword = "nFb0ium6/SBSYgNL/MIjKyxjNIy3I9aB7DnxNAn5kMw=",
                }
            }
            : AppUsers;
    }
    
    public void SaveToFile()
    {
        AppUsers = LocalDb.Users;
        Prisoners = LocalDb.Prisoners;
        File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
    }

}