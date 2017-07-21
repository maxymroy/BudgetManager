using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models
{
    public class Indicators
    {
        public int Id { get; set; }
        public char Indicator { get; set; }

        public Indicators(int id, char indicator)
        {
            this.Id = id;
            this.Indicator = indicator;
        }
    }
}