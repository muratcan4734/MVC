using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sınav.Controllers
{
    public class ParfumController : Controller
    {
        // GET: Parfum

        MVCParfumEntities db = new MVCParfumEntities();


        public ActionResult List()
        {

            return View(db.Perfumes.ToList());
        }

        [HttpGet]

        public ActionResult Add()
        {
            return View(db.Perfumes.ToList());
        }

        [HttpPost]

        public RedirectToRouteResult Add(Sınav.Perfume data)
        {
            db.Perfumes.Add(data);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Perfume silinicek = db.Perfumes.Find(id);
            db.Perfumes.Remove(silinicek);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Perfume guncellenecek = db.Perfumes.Find(id);
            ViewBag.marka = db.Brands.ToList();
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(Perfume data)
        {
            Perfume guncellenecek = db.Perfumes.Find(data.PerfumeId);
            guncellenecek.PerfumeName = data.PerfumeName;
            guncellenecek.Price = data.Price;
            db.SaveChanges();
            return RedirectToAction("List");

        }

    }
}