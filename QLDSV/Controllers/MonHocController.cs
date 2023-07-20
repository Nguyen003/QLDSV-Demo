using QLDSV.Constant;
using QLDSV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLDSV.Controllers
{
    public class MonHocController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MonHoc
        public ActionResult Index()
        {
            var listMon = db.MonHocs.ToList();
            return View(listMon);
        }

        // GET: MonHoc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonHoc/Create
        public ActionResult Create()
        {
            LoaiMonHoc lmonHoc = new LoaiMonHoc();
            ViewBag.LoaiMonHoc = new SelectList(lmonHoc.GetListLoaiMonHoc(), "LoaiMonHocID", "TenLoaiMonHoc");
            return View();
        }

        // POST: MonHoc/Create
        [HttpPost]
        public ActionResult Create(MonHoc monHoc)
        {
            MonHoc mh = db.MonHocs.FirstOrDefault(x => x.MaMonHoc == monHoc.MaMonHoc);
            LoaiMonHoc lmonHoc = new LoaiMonHoc();
            ViewBag.LoaiMonHoc = new SelectList(lmonHoc.GetListLoaiMonHoc(), "LoaiMonHocID", "TenLoaiMonHoc");
            if(mh != null)
            {
                ModelState.AddModelError("","Mã môn học đã tồn tại");
                return View(monHoc);
            }
            if(ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monHoc);
        }

        // GET: MonHoc/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            LoaiMonHoc lmh = new LoaiMonHoc();
            ViewBag.LoaiMonHoc = new SelectList(lmh.GetListLoaiMonHoc(), "LoaiMonHocID", "TenLoaiMonHoc", monHoc.LoaiMonHoc);
            return View(monHoc);
        }

        // POST: MonHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(MonHoc monHoc)
        {
            LoaiMonHoc lmh = new LoaiMonHoc();
            ViewBag.LoaiMonHoc = new SelectList(lmh.GetListLoaiMonHoc(), "LoaiMonHocID", "TenLoaiMonHoc");
            MonHoc mh = db.MonHocs.FirstOrDefault(x => x.MaMonHoc == monHoc.MaMonHoc);
            if (ModelState.IsValid)
            {
                var oldItem = db.MonHocs.Find(monHoc.MonHocID);
                oldItem.MaMonHoc = monHoc.MaMonHoc;
                oldItem.TenMonHoc = monHoc.TenMonHoc;
                oldItem.SoTinChi = monHoc.SoTinChi;
                oldItem.LoaiMonHoc = monHoc.LoaiMonHoc;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: MonHoc/Delete/5
        public ActionResult Delete(int id)
        {
            MonHoc mh = db.MonHocs.Find(id);
            if(mh == null )
            {
                return HttpNotFound();
            }
            LoaiMonHoc lmh = new LoaiMonHoc();
            ViewBag.LoaiMonHoc = new SelectList(lmh.GetListLoaiMonHoc(), "LoaiMonHocID", "TenLoaiMonHoc");
            return View(mh);
        }

        // POST: MonHoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MonHoc mh = db.MonHocs.Find(id);
                db.MonHocs.Remove(mh);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
