using System.Dynamic;

namespace CursachFront.Core.Models;
public enum Status
{
    Alive,
    Die,
    Terminated,
    Prisoned,
    None
}
public class Prisoner
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }

    public string Hospital { get; set; }
    public DateTime? Birthday { get; set; }
    public string ColorHair { get; set; }
    public string Country { get; set; }
    public string LastSee { get; set; }
    public Status _Status { get; set; }


    public string CriminalArticles { get; set; }
    public string PhotoName { get; set; }
    public string FingerName { get; set; }
    public double Weight { get; set; }
    public string EyeColor {  get; set; }
    public string Hobbies { get; set; } 
    public string BloodType { get; set; }
    public string Profession { get; set; }
    public bool Married { get; set; }
    public string CivilSpec { get; set; }
    public string CrimeSpec { get; set; }
    public string Gang { get; set; }
    public string FirstCrimes { get; set; }
    public string BIO { get; set; } 
}