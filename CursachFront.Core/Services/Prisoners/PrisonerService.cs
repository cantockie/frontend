using System.Security.Principal;
using CursachFront.Core.Models;
using CursachFront.Core.Models.FilterUsers;

namespace CursachFront.Core.Services.Prisoners;

public class PrisonerService
{
    public IEnumerable<Prisoner> GetFilteredAsync(SearchFilter filter)
    {
        // if (!LocalIdentity.IsInRole)
        //     throw new Exception("Unathorized");
        
        return LocalDb.Prisoners.Where(prp =>
            (string.IsNullOrEmpty(filter.Name) || prp.Name.Contains(filter.Name))
            && (string.IsNullOrEmpty(filter.Surname) || prp.Surname.Contains(filter.Surname))
            && (string.IsNullOrEmpty(filter.Hospital) || prp.Hospital.Contains(filter.Hospital))
            && (filter.Birthday is null || prp.Birthday.Equals(filter.Birthday))
            && (string.IsNullOrEmpty(filter.ColorHair) || prp.ColorHair.Contains(filter.ColorHair))
            && (string.IsNullOrEmpty(filter.Country) || prp.Country.Contains(filter.Country))
            && (string.IsNullOrEmpty(filter.LastSee) || prp.LastSee.Contains(filter.LastSee))
            && (string.IsNullOrEmpty(filter.CriminalArticles) || prp.CriminalArticles.Contains(filter.CriminalArticles))
        );
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