using ManagementApp.DataContext;
using ManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class FrequencyRepository
    {
        public IEnumerable<Frequencies> GetAllIndicators()
        {
            using (var DataContext = new Entities())
            {
                return DataContext.Frequencies.ToList();
            }
        }
    }
}