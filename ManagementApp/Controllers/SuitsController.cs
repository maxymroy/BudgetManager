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
            clothesRepo.CreateClothes(new Clothes {ClothesType = newClothes.ClothesType,AdditionnalNote = newClothes.AdditionnalNote,Color = newClothes.Color,Image = newClothes.Image });
            return Content("Success :)");
        }




        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Clothes()
        {
            List<ClothesModel> clothesModel = new List<ClothesModel>();
            ClothesRepository clothesRepo = new ClothesRepository();
            ColorRepository colorRepo = new ColorRepository();
            ClothesTypeRepository clothesTypeRepo = new ClothesTypeRepository();
            var allCLothes = clothesRepo.GetAllClothes();
            foreach(var clothe in allCLothes.OrderBy(c=>c.ClothesType))
            {
                clothesModel.Add(new ClothesModel {Id = clothe.Id,
                    AdditionnalNote = clothe.AdditionnalNote == null ? "N/A" : clothe.AdditionnalNote,
                    ClothesType = clothesTypeRepo.GetAllClothingTypes().Where(t => t.Id == clothe.ClothesType).SingleOrDefault().Name,
                    Color = colorRepo.GetAllColors().Where(c => c.Id == clothe.Color).SingleOrDefault().Name, Image = clothe.Image == null ? "" : clothe.Image
                });
            }
            return Json(clothesModel, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Colors()
        {
            ColorRepository colorRepo = new ColorRepository();
            return Json(colorRepo.GetAllColors(), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult ClothesTypes()
        {
            ClothesTypeRepository clothesTypeRepo = new ClothesTypeRepository();
            return Json(clothesTypeRepo.GetAllClothingTypes(), JsonRequestBehavior.AllowGet);
        }
    }
}