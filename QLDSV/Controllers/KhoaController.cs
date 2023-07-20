using PagedList;
using QLDSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace QLDSV.Controllers
{
    public class KhoaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Khoa
        public ActionResult Index(int? page, string search)
        {
            var sinhVien = from l in db.Khoas select l;
            if (!String.IsNullOrEmpty(search))
            {
                sinhVien = sinhVien.Where(s => s.TenKhoa.Contains(search));
            }

            if (search != null) page = 1;
            var sinhvien = sinhVien.OrderBy(b => b.TenKhoa);
            var pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sinhvien.ToPagedList(pageNumber, pageSize));
        }

        // GET: Khoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Khoa/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Khoa/Create
        [HttpPost]
        public ActionResult Create(Khoa model)
        {
            try
            {
                // TODO: Add insert logic here
                db.Khoas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khoa/Edit/5
        public ActionResult Edit(int id)
        {
            Khoa khoa = db.Khoas.Find(id);
            return View(khoa);
        }

        // POST: Khoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Khoa model)
        {
            try
            {
                // TODO: Add update logic here
                var oldItem = db.Khoas.Find(model.KhoaID);
                oldItem.MaKhoa = model.MaKhoa;
                oldItem.TenKhoa = model.TenKhoa;
                oldItem.KiHieu = model.KiHieu;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khoa/Delete/5
        public ActionResult Delete(int id)
        {
            Khoa khoa = db.Khoas.Find(id);
            if(khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Khoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Khoa khoa = db.Khoas.Find(id);
                db.Khoas.Remove(khoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
