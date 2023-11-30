namespace CursachFront.Core.Models.FilterUsers;

public class SearchFilter
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Hospital { get; set; }
    public DateTime? Birthday { get; set; }
    public string ColorHair { get; set; }
    public string Country { get; set; }
    public string LastSee { get; set; }
    public string CriminalArticles { get; set; }
}