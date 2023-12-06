using System.Security.Principal;
using CursachFront.Core.Models;
using CursachFront.Core.Models.FilterUsers;

namespace CursachFront.Core.Services.Prisoners;

public class PrisonerService : IPrisonerService
{
    private readonly CursachConfiguration _configuration;
    public PrisonerService()
    {
        _configuration = new CursachConfiguration();
    }
    public IEnumerable<Prisoner> GetFilteredAsync(SearchFilter filter)
    {
        DateTime? birthday = string.IsNullOrEmpty(filter.Birthday) ? null : (DateTime?)DateTime.Parse(filter.Birthday);

        return LocalDb.Prisoners.Where(prp =>
            (string.IsNullOrEmpty(filter.Name) || prp.Name.Contains(filter.Name)) &&
            (string.IsNullOrEmpty(filter.Surname) || prp.Surname.Contains(filter.Surname)) &&
            (string.IsNullOrEmpty(filter.Country) || prp.Country.Contains(filter.Country)) &&
            (string.IsNullOrEmpty(filter.CrimeSpec) || prp.CrimeSpec.Contains(filter.CrimeSpec)) &&
            (!birthday.HasValue || prp.Birthday == birthday) &&
            (string.IsNullOrEmpty(filter.ColorHair) || prp.ColorHair.Contains(filter.ColorHair)) &&
            (string.IsNullOrEmpty(filter.EyeColor) || prp.EyeColor.Contains(filter.EyeColor))
        );
    }


    public IEnumerable<Prisoner> GetFilteredShort(SearchFilter filter)
    {
        if (string.IsNullOrEmpty(filter.Status) || Enum.TryParse(filter.Status, out CursachFront.Core.Models.Status statusEnum))
        {
            return LocalDb.Prisoners.Where(prp =>
                (string.IsNullOrEmpty(filter.Country) || prp.Country.Contains(filter.Country)) &&
                (string.IsNullOrEmpty(filter.Gang) || prp.Gang.Contains(filter.Gang)) &&
                (string.IsNullOrEmpty(filter.Status) || prp._Status.ToString() == filter.Status)
            );
        }
        else
        {
            throw new ArgumentException("Invalid status string.");
        }
    }
    public void Add(Prisoner prisoner)
    {
        int Id = LocalDb.Prisoners.Count + 1;
        prisoner.Id = Id;
        LocalDb.Prisoners.Add(prisoner);
        _configuration.SaveToFile();
    }

    public void Update(Prisoner prisoner)
    {
        var data = LocalDb.Prisoners.FirstOrDefault(prp => prp.Id.Equals(prisoner.Id));
        if (data is null)
            throw new Exception("Prisoner not found");
        data.Name = prisoner.Name;
        data.Surname = prisoner.Surname;
        data.Gender = prisoner.Gender;
        data.BIO = prisoner.BIO;
        data.Country = prisoner.Country;
        data.Weight = prisoner.Weight;
        data.Gender = prisoner.Gender;
        data.FirstCrimes = prisoner.FirstCrimes;
        data.Profession = prisoner.Profession;
        data.BloodType = prisoner.BloodType;
        data.Gang = prisoner.Gang;
        data.Married = prisoner.Married;
        data.Hobbies = prisoner.Hobbies;
        data.ColorHair = prisoner.ColorHair;
        data.EyeColor = prisoner.EyeColor;
        data.LastSee = prisoner.LastSee;
        data.CivilSpec = prisoner.CivilSpec;
        data._Status = prisoner._Status;
        data.CriminalArticles = prisoner.CriminalArticles;
        data.Hospital = prisoner.Hospital;
        data.FingerName = prisoner.FingerName;
        data.PhotoName = prisoner.PhotoName;
        data.CrimeSpec = prisoner.CrimeSpec;

        
        //data = prisoner;
        _configuration.SaveToFile();
    }

    public void Remove(long Id)
    {
        var prisoner = LocalDb.Prisoners.FirstOrDefault(prp => prp.Id.Equals(Id));
        if (prisoner is null)
            throw new Exception("Prisoner not found");

        LocalDb.Prisoners.Remove(prisoner);
        _configuration.SaveToFile();
        
    }
    public List<Prisoner> GetList()
           => LocalDb.Prisoners.ToList();

}