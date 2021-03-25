using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahat_.Models.Siniflar;

namespace TatilSeyahat_.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        // GET: Blog
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            // var degerler = c.Blogs.ToList();

           by.Deger1 = c.Blogs.ToList();
           by.Deger3 = c.Blogs.OrderByDescending(x=> x.ID).Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            // var blogbul = c.Blogs.Where(x => x.ID == id).ToList();

            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.yorumlars.Where(x => x.Blogid == id).ToList();

            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }

    }
}