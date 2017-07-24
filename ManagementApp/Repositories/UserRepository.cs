using ManagementApp.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class UserRepository
    {
        public IEnumerable<Users> GetAllUsers()
        {
            using (var DataContext = new Entities())
            {
                return DataContext.Users.ToList();
            }
        }

        public void CreateUser(Users user)
        {
            using (var DataContext = new Entities())
            {
                DataContext.Users.Add(user);
                DataContext.SaveChanges();
            }
        }
        public Users GetUser(int id)
        {
            using (var DataContext = new Entities())
            {
                return DataContext.Users.Where(m => m.Id == id).SingleOrDefault();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var DataContext = new Entities())
            {
                DataContext.Users.Remove(DataContext.Users.Where(u => u.Id == userId).SingleOrDefault());
                DataContext.SaveChanges();
            }
        }

        public void ModifyUsers(IEnumerable<Users> users)
        {
            using (var DataContext = new Entities())
            {
                foreach(var user in users)
                {
                    DataContext.Users.Attach(user);

                    var entry = DataContext.Entry(user);
                    entry.State = System.Data.Entity.EntityState.Modified;

                    entry.Property(e => e.Name).IsModified = true;

                    DataContext.SaveChanges();
                }
            }
        }
    }
}