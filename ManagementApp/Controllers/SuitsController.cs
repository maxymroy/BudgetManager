using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ManagementApp.Controllers
{
    public class SuitsController : Controller
    {
        private static readonly IList<CommentModel> _comments;
        static SuitsController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                },
            };
        }
        // GET: Suit
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AddClothes(Clothes newClothes)
        {
            ClothesRepository clothesRepo = new ClothesRepository();
            clothesRepo.CreateClothes(newClothes);
            return Content("Success :)");
        }




        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Clothes()
        {
            ClothesRepository clothesRepo = new ClothesRepository();
            var allCLothes = clothesRepo.GetAllClothes();
            foreach(var clothe in allCLothes)
            {
                if(clothe.AdditionnalNote == null)
                {
                    clothe.AdditionnalNote = "";
                }
            }
            return Json(allCLothes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }
    }
}