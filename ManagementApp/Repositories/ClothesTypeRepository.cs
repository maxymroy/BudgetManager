using ManagementApp.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class ClothesTypeRepository
    {
        public List<ClothingType> GetAllClothingTypes()
        {
            using (var dataContext = new Entities())
            {
                return dataContext.ClothingType.ToList();
            }
        }
    }
}