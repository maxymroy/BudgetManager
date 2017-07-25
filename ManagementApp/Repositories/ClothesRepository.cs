using ManagementApp.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class ClothesRepository
    {
        public IEnumerable<Clothes> GetAllClothes()
        {
            using (var datacontext = new Entities())
            {
                return datacontext.Clothes.ToList();
            }
        }

        public IEnumerable<Clothes> GetSuitsClothes(int suitId)
        {
            using (var datacontext = new Entities())
            {
                return datacontext.Clothes.Where(c => c.Id == suitId);
            }
        }

        public void CreateClothes(Clothes clothes)
        {
            using (var datacontext = new Entities())
            {
                datacontext.Clothes.Add(clothes);
            }
        }
    }
}