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
    public class SinhViens_61131562Controller : Controller
    {
        private THI_61131562Entities db = new THI_61131562Entities();

        // GET: SinhViens_61131562
        public ActionResult GioiThieu_61131562()
        {
            return View();
        }
        public ActionResult TimKiem_61131562()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop).Include(s => s.NganhHoc);
            return View(sinhViens.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem_61131562(string maSV, string tenSV)
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop).Include(s => s.NganhHoc);
            if ((maSV != "") && (tenSV != ""))
            {
                sinhViens = db.SinhViens.Include(s => s.Lop).Include(s =>s.NganhHoc).Where(sv => (sv.MaSV == maSV) && (sv.TenSV).Contains(tenSV));
            }
            else if ((maSV != "") && (tenSV == ""))
            {
                sinhViens = db.SinhViens.Include(s => s.Lop).Where(sv => (sv.MaSV == maSV));
            }
            else if ((maSV == "") && (tenSV != ""))
            {
                sinhViens = db.SinhViens.Include(s => s.Lop).Where(sv => (sv.TenSV).Contains(tenSV));
            }
            else if (sinhViens.Count() == 0)
                ViewBag.TB = "Không có thông cần tìm";
            return View(sinhViens.ToList());
        }
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop).Include(s => s.NganhHoc);
            return View(sinhViens.ToList());
        }

        // GET: SinhViens_61131562/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens_61131562/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh");
            return View();
        }

        // POST: SinhViens_61131562/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,GioiTinh,NgaySinh,AnhSV,DiaChi,TonGiao,DanToc,SDT,CMND,HeDT,HoTenCha,NgaySinhCha,NgheNghiepCha,HoTenMe,NgaySinhMe,NgheNghiepMe,Email,MaLop,MaNganh")] SinhVien sinhVien)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgSV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSV.SaveAs(path);

            if (ModelState.IsValid)
            {
                sinhVien.AnhSV = postedFileName;
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // GET: SinhViens_61131562/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // POST: SinhViens_61131562/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,GioiTinh,NgaySinh,AnhSV,DiaChi,TonGiao,DanToc,SDT,CMND,HeDT,HoTenCha,NgaySinhCha,NgheNghiepCha,HoTenMe,NgaySinhMe,NgheNghiepMe,Email,MaLop,MaNganh")] SinhVien sinhVien)
        {
            var imgSV = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Images/" + postedFileName);
                imgSV.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            ViewBag.MaNganh = new SelectList(db.NganhHocs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            return View(sinhVien);
        }

        // GET: SinhViens_61131562/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens_61131562/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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
