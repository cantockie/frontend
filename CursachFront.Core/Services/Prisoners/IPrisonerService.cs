using CursachFront.Core.Models.FilterUsers;
using CursachFront.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachFront.Core.Services.Prisoners
{
    internal interface IPrisonerService
    {
        IEnumerable<Prisoner> GetFilteredAsync(SearchFilter filter);
        IEnumerable<Prisoner> GetFilteredShort(SearchFilter filter);
        void Add(Prisoner prisoner);
        void Update(Prisoner prisoner);
        void Remove(long Id);
        List<Prisoner> GetList();
    }
}
