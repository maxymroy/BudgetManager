using ManagementApp.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class ColorRepository
    {
        public List<Color> GetAllColors()
        {
            using (var dataContext = new Entities())
            {
                return dataContext.Color.ToList();
            }
        }
    }
}