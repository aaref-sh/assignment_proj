using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment_proj.Models;

namespace assignment_proj.Controllers
{
    public class HomeController : Controller
    {
        private DB db = new DB();

        // GET: Categories
        public ActionResult Index()
        {
            ViewBag.categories = new SelectList(db.Categories, "Id", "Name");
            return View(db.Categories.ToList());
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.cats = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category,int? Father)
        {
            try
            {
                category.Father = db.Categories.Find(Father);
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.cats = new SelectList(db.Categories, "Id", "Name");
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult GetChildItems(int? Id)
        {
            var cats = db.Categories.ToList();
            if(Id.HasValue)
                cats = db.Categories.Where(x => x.Father.Id == Id).ToList();
            string res = "<br /><select class=\"form-select slct\" onchange=\"change()\"><option value=\"-1\">---اختيار---</option>";
            if (cats != null)
                res += string.Join("", cats.Select(c => $"<option value=\"{c.Id}\">{c.Name}</option>"));
            res += "<select>";
            if (cats.Count == 0) res = "";
            return Content(res);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
