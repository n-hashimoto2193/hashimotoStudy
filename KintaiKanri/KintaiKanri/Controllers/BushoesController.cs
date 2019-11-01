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
    public class BushoesController : Controller
    {
        private KintaiKanriContext db = new KintaiKanriContext();

        // GET: Bushoes
        public ActionResult Index()
        {
            return View(db.Bushoes.ToList());
        }

        // GET: Bushoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Busho busho = db.Bushoes.Find(id);
            if (busho == null)
            {
                return HttpNotFound();
            }
            return View(busho);
        }

        // GET: Bushoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bushoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BushoName")] Busho busho)
        {
            if (ModelState.IsValid)
            {
                db.Bushoes.Add(busho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busho);
        }

        // GET: Bushoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Busho busho = db.Bushoes.Find(id);
            if (busho == null)
            {
                return HttpNotFound();
            }
            return View(busho);
        }

        // POST: Bushoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BushoName")] Busho busho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busho);
        }

        // GET: Bushoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Busho busho = db.Bushoes.Find(id);
            if (busho == null)
            {
                return HttpNotFound();
            }
            return View(busho);
        }

        // POST: Bushoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Busho busho = db.Bushoes.Find(id);
            db.Bushoes.Remove(busho);
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
    }
}
