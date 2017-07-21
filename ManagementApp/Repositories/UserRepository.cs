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
        public Users GetUser(int id)
        {
            using (var DataContext = new Entities())
            {
                return DataContext.Users.Where(m => m.Id == id).SingleOrDefault();
            }
        }
    }
}