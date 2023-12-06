using CursachFront.Core.Models;
using CursachFront.Core.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CursachFront.Core.Services.Users
{
   public class UserService : IUserService
    {
        private readonly CursachConfiguration _configuration;
        public UserService()
        {
            _configuration = new CursachConfiguration();
        }
        public void Add(AppUser au)
        {
            int Id = LocalDb.Users.Count + 1;
            au.Id = Id;
            var hashed = GenPassword(au.HashedPassword);
            au.HashedPassword = hashed;
            LocalDb.Users.Add(au);
            _configuration.SaveToFile();
        }

        public void Update(AppUser au)
        {
            var data = LocalDb.Users.FirstOrDefault(user => user.Id.Equals(au.Id));
            if (data is null)
                throw new Exception("Prisoner not found");
            var hashed = GenPassword(au.HashedPassword);
            au.HashedPassword = hashed;
            data = au;
            data.Rank = au.Rank;
            data.Email = au.Email;
            data.Education = au.Education;
            data.HashedPassword = hashed;
            data.BirthDay = au.BirthDay;
            data.Departments = au.Departments;
            data.Id = au.Id;
            data.Role = au.Role;
            data.Bio = au.Bio;
            data.PhotoName = au.PhotoName;
            data.FingerName = au.FingerName;
            data.Gender = au.Gender;
            data.BirthDay = au.BirthDay;
            data.Country = au.Country;
            data.Specifications = au.Specifications;
            data.Username = au.Username;
            _configuration.SaveToFile();
        }

        public void Remove(long Id)
        {
            var user = LocalDb.Users.FirstOrDefault(prp => prp.Id.Equals(Id));
            if (user is null)
                throw new Exception("Prisoner not found");

            LocalDb.Users.Remove(user);
            _configuration.SaveToFile();
        }
        public List<AppUser> GetList()
            => LocalDb.Users.ToList();
        private static byte[] GenerateSalt()
        {
            const int SaltLength = 64;
            byte[] salt = new byte[SaltLength];

            var rngRand = new RNGCryptoServiceProvider();
            rngRand.GetBytes(salt);

            return salt;
        }
        private static byte[] GenerateSha256Hash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var hash = new SHA256CryptoServiceProvider();

            return hash.ComputeHash(saltedPassword);
        }
        private string GenPassword(string d)
        {

            var salt = GenerateSalt();
            var hash = Convert.ToBase64String(GenerateSha256Hash(d, salt));
            return hash;
        }


    }
}

