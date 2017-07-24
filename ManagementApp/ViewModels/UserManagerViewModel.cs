using ManagementApp.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class UserManagerViewModel
    {
        public IEnumerable<Users> Users { get; set; }
    }
}