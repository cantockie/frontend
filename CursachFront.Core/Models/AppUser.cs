namespace CursachFront.Core.Models;

public class AppUser
{
  public long Id { get; set; }
  public string Role { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Rank { get; set; }
  public string Gender { get; set; }

  public DateTime BirthDay { get; set; }
  public string Education { get; set; }
    public string Country { get; set; }
  public string Departments { get; set; }
  public string Specifications { get; set; }
    public string Email { get; set; }
    public int Protection { get; set; }
  public string HashedPassword { get; set; }
  public string Username { get; set; }
}