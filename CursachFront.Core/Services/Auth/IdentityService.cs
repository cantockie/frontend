using System.Security.Cryptography;
using System.Text;
using CursachFront.Core.Models;

namespace CursachFront.Core.Services.Auth;

public class IdentityService
{
    public void SignIn(string username, string password)
    {
        var salt = GenerateSalt();
        var hashed_password = Convert.ToBase64String(GenerateSha256Hash(password, salt));
        var user = AuthorizeUser(username, hashed_password); 
        if (user is null)
            throw new Exception("User not found");

        LocalIdentity.User = user;
    }

    public void SignOut()
    {
        LocalIdentity.User = null;
    }

    private AppUser AuthorizeUser(string username, string password)
        => LocalDb.Users.FirstOrDefault(prp => prp.Username.Equals(username) && prp.HashedPassword.Equals(password));
    
    protected static byte[] GenerateSalt()
    {
        const int SaltLength = 64;
        byte[] salt = new byte[SaltLength];

        var rngRand = new RNGCryptoServiceProvider();
        rngRand.GetBytes(salt);

        return salt;
    }
    protected static byte[] GenerateSha256Hash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

        using var hash = new SHA256CryptoServiceProvider();

        return hash.ComputeHash(saltedPassword);
    }
    public string GenPassword(string password)
    {

        var salt = GenerateSalt();
        var hash = Convert.ToBase64String(GenerateSha256Hash(password, salt));
        return hash;
    }
}