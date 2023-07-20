using QLDSV.Models;
using QLDSV.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLDSV.Controllers
{
    public class NganhDaoTaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: NganhDaoTao
        public ActionResult Index()
        {
            var listNganh = db.NganhDaoTaos.ToList();
            return View(listNganh);
        }

        //public ActionResult ThemMonHocVaoNganh(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
        //    if (nganhDaoTao == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", nganhDaoTao.KhoaID);
        //    ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", id);
        //    var data = db.MonHocs.ToList();
        //    ViewData["dataMonHoc"] = data;
        //    return View(nganhDaoTao);
        //}

        // GET: NganhDaoTao/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
            if(nganhDaoTao == null)
            {
                return HttpNotFound();
            }
            var danhsachMonHoc = db.NganhDaoTao_MonHoc
                .Join(db.MonHocs, ndt => ndt.MonHocID, mh => mh.MonHocID, (ndt, mh) => new {ndt, mh})
                .Join(db.NganhDaoTaos, o1 => o1.ndt.NganhDaoTaoID, o2 => o2.NganhDaoTaoID, (o1, o2) => new NganhDaoTaoMonHocViewModel
                {
                    NganhDaoTao = o2,
                    MonHoc = o1.mh
                })
                .Where (x => x.NganhDaoTao.NganhDaoTaoID == id)
                .ToList();
            ViewData["DanhSachMonHoc"] = danhsachMonHoc;
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", nganhDaoTao.KhoaID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", id);
            return View(nganhDaoTao);
        }

        // GET: NganhDaoTao/Create
        public ActionResult Create()
        {
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
            return View();
        }

        // POST: NganhDaoTao/Create
        [HttpPost]
        public ActionResult Create(NganhDaoTao model)
        {
            if(ModelState.IsValid)
            {
                db.NganhDaoTaos.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", model.KhoaID);
            return View(model);
        }

        // GET: NganhDaoTao/Edit/5
        public ActionResult Edit(int id)
        {
            NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
            if (nganhDaoTao == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", nganhDaoTao.KhoaID);
            return View(nganhDaoTao);
        }

        // POST: NganhDaoTao/Edit/5
        [HttpPost]
        public ActionResult Edit(NganhDaoTao model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", model.KhoaID);
            return View(model);
        }

        // GET: NganhDaoTao/Delete/5
        public ActionResult Delete(int id)
        {
            NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
            return View(nganhDaoTao);
        }

        // POST: NganhDaoTao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                NganhDaoTao nganhDaoTao = db.NganhDaoTaos.Find(id);
                db.NganhDaoTaos.Remove(nganhDaoTao);
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
