using CursachFront.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachFront.Core.Services.Users
{
   public class UserService
    {
        public void Add(AppUser au)
        {
            int Id = LocalDb.Users.Count + 1;
            au.Id = Id;
            LocalDb.Users.Add(au);
        }

        public void Update(AppUser au)
        {
            var data = LocalDb.Users.FirstOrDefault(user => user.Id.Equals(au.Id));
            if (data is null)
                throw new Exception("Prisoner not found");

            data = au;
        }

        public void Remove(long Id)
        {
            var user = LocalDb.Users.FirstOrDefault(prp => prp.Id.Equals(Id));
            if (user is null)
                throw new Exception("Prisoner not found");

            LocalDb.Users.Remove(user);
        }

    }
}

