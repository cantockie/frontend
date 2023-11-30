using CursachFront.Core.Models;
using Newtonsoft.Json;

namespace CursachFront.Core;

public class CursachConfiguration
{
    private static string fileName = "localDb.json";
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
        AppUsers = new List<AppUser>() {
new()
                {
                    Username = "admin@gmail.com",
                    HashedPassword = "nFb0ium6/SBSYgNL/MIjKyxjNIy3I9aB7DnxNAn5kMw=",
                },
                new()
                {
                    Username = "user@gmail.com",
                    HashedPassword = "0IAM0V+LhJgjIg96EvuqZl/kJu0d2xO2DsuJpdQSwd4="
                },
                new()
                {
                    Username = "manager@gmail.com",
                    HashedPassword = "g0pwm6JTTr4+4Tl/1Pe9KIsqzB0goI1shi3NmbbwRAA="
                },
                new()
                {
                    Username = "null@gmail.com",
                    HashedPassword = "NnRn9D1YDDwHBAp4x4kK5CYtrUd4h4+aSdX2UsgWiaU="
                }
        };
        Prisoners = LocalDb.Prisoners;
        File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
    }

}