using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTap2_61131562.Models;

namespace BaiTap2_61131562.Controllers
{
    public class SinhVien_61131562Controller : Controller
    {
        // GET: SinhVien_61131562
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register2(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return View(ViewBag);
        }        public ActionResult UseModel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UseModel(SVModel sV)
        {
            ViewBag.Id = sV.Id;
            ViewBag.Name = sV.Name;
            ViewBag.Marks = sV.Marks;
            return View();
        }
    }
}