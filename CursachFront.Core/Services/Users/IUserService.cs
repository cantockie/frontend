using CursachFront.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachFront.Core.Services.Users
{
    public interface IUserService
    {

        void Add(AppUser au);
        void Update(AppUser au);
        void Remove(long Id);
    }

}
