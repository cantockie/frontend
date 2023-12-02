using System.Data;

namespace CursachFront.Core.Models;

public class ProfileData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string Education { get; set; }
    public string Country { get; set; }
    public string Rank { get; set; }
    public string ProfileImage { get; set; }

    public string Gender { get; set; }

    public DateTime BirthDay { get; set; }
    public string Departments { get; set; }
    
    public string Email { get; set; }
    public string Specifications { get; set; }
    public string Bio { get; set; }
    public long Id { get; set; }
}