using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Thi_61131562.Models;

namespace Thi_61131562.Controllers
{
    public class DocGia_61131562Controller : Controller
    {
        private Thi_61131562Entities db = new Thi_61131562Entities();

        // GET: DocGia_61131562
        public ActionResult GioiThieu_61131562()
        {
            return View();
        }
        public ActionResult Index()
        {
            var docGias = db.DocGias.Include(d => d.LoaiDocGia);
            return View(docGias.ToList());
        }

        // GET: DocGia_61131562/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // GET: DocGia_61131562/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoaiDocGia");
            return View();
        }

        // POST: DocGia_61131562/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDocGia")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.DocGias.Add(docGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoaiDocGia", docGia.MaLoaiDocGia);
            return View(docGia);
        }

        // GET: DocGia_61131562/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoaiDocGia", docGia.MaLoaiDocGia);
            return View(docGia);
        }

        // POST: DocGia_61131562/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDocGia")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDocGia = new SelectList(db.LoaiDocGias, "MaLoaiDocGia", "TenLoaiDocGia", docGia.MaLoaiDocGia);
            return View(docGia);
        }

        // GET: DocGia_61131562/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGia_61131562/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DocGia docGia = db.DocGias.Find(id);
            db.DocGias.Remove(docGia);
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
