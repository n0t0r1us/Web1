using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THIDinhVu_61131562.Models;

namespace THIDinhVu_61131562.Controllers
{
    public class NganhHocs_61131562Controller : Controller
    {
        private THI_61131562Entities db = new THI_61131562Entities();

        // GET: NganhHocs_61131562
        public ActionResult Index()
        {
            return View(db.NganhHocs.ToList());
        }

        // GET: NganhHocs_61131562/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            if (nganhHoc == null)
            {
                return HttpNotFound();
            }
            return View(nganhHoc);
        }

        // GET: NganhHocs_61131562/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NganhHocs_61131562/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNganh,TenNganh")] NganhHoc nganhHoc)
        {
            if (ModelState.IsValid)
            {
                db.NganhHocs.Add(nganhHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nganhHoc);
        }

        // GET: NganhHocs_61131562/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            if (nganhHoc == null)
            {
                return HttpNotFound();
            }
            return View(nganhHoc);
        }

        // POST: NganhHocs_61131562/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNganh,TenNganh")] NganhHoc nganhHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganhHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nganhHoc);
        }

        // GET: NganhHocs_61131562/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            if (nganhHoc == null)
            {
                return HttpNotFound();
            }
            return View(nganhHoc);
        }

        // POST: NganhHocs_61131562/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NganhHoc nganhHoc = db.NganhHocs.Find(id);
            db.NganhHocs.Remove(nganhHoc);
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
