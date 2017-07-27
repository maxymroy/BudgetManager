using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Models
{
    public class ClothesModel
    {
        public int Id { get; set; }
        public string AdditionnalNote { get; set; }
        public string Color { get; set; }
        public string ClothesType { get; set; }
        public string Image { get; set; }
    }
}