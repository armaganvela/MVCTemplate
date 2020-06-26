using Test.Core.Models;
using Test.Sql;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<ApplicationUser> GetUsers()
        {
            return db.Users.ToList();
        }

        public ApplicationUser GetUser(string userId)
        {
            return db.Users.FirstOrDefault(x=>x.Id == userId);
        }

        public void Update(ApplicationUser user)
        {
            var entry = db.Entry(user);
            entry.State = EntityState.Modified;

            db.SaveChanges();

        }
    }
}
