using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KintaiKanri.Models;

namespace KintaiKanri.Controllers
{
    public class SyainsController : Controller
    {
        private KintaiKanriContext db = new KintaiKanriContext();

        //private readonly KintaiKanriContext _context;

        //public SyainsController(KintaiKanriContext context)
        //{
        //    _context = context;
        //}

        // GET: Syains
        public ActionResult Index()
        {
            return View(db.Syains.ToList());
        }

        // GET: Syains/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Syain syain = db.Syains.Find(id);
            if (syain == null)
            {
                return HttpNotFound();
            }
            return View(syain);
        }

        // GET: Syains/Create
        public ActionResult Create()
        {
            // 部署リスト
            SetBushoList();

            return View();
        }

        // POST: Syains/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SyainName,No,Email")] Syain syain)
        {
            if (ModelState.IsValid)
            {
                db.Syains.Add(syain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(syain);
        }

        // GET: Syains/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Syain syain = db.Syains.Find(id);
            if (syain == null)
            {
                return HttpNotFound();
            }
            return View(syain);
        }

        // POST: Syains/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SyainName,No,Email")] Syain syain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(syain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(syain);
        }

        // GET: Syains/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Syain syain = db.Syains.Find(id);
            if (syain == null)
            {
                return HttpNotFound();
            }
            return View(syain);
        }

        // POST: Syains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Syain syain = db.Syains.Find(id);
            db.Syains.Remove(syain);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetBushoList()
        {
            ViewBag.BushoList = db.Bushoes.Select(t => new SelectListItem
            {
                Text = t.BushoName,
                Value = t.BushoName
            });
        }
    }
}
