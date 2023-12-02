using System.Security.Principal;
using CursachFront.Core.Models;
using CursachFront.Core.Models.FilterUsers;

namespace CursachFront.Core.Services.Prisoners;

public class PrisonerService
{
    
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
                (string.IsNullOrEmpty(filter.Status) || prp.Status.ToString() == filter.Status)
            );
        }
        else
        {
            throw new ArgumentException("Invalid status string.");
        }
    }
    public void Add(Prisoner prisoner)
        => LocalDb.Prisoners.Add(prisoner);

    public void Update(Prisoner prisoner)
    {
        var data = LocalDb.Prisoners.FirstOrDefault(prp => prp.Id.Equals(prisoner.Id));
        if (data is null)
            throw new Exception("Prisoner not found");

        data = prisoner;
    }

    public void Remove(long Id)
    {
        var prisoner = LocalDb.Prisoners.FirstOrDefault(prp => prp.Id.Equals(Id));
        if(prisoner is null)
            throw new Exception("Prisoner not found");

        LocalDb.Prisoners.Remove(prisoner);
    }
    
}