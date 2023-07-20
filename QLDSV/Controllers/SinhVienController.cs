using PagedList;
using QLDSV.Constant;
using QLDSV.Models;
using QLDSV.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace QLDSV.Controllers
{
    public class SinhVienController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SinhVien
        public ActionResult Index(int? page, string search)
        {
            var sinhVien = from l in db.SinhViens select l;
            if(!String.IsNullOrEmpty(search))
            {
                sinhVien = sinhVien.Where(s => s.HoTen.Contains(search));
            }

            if (search != null) page = 1;
            var sinhvien = sinhVien.OrderBy(b => b.HoTen);
            var pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sinhvien.ToPagedList(pageNumber, pageSize));
        }

        // GET: SinhVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinhVien/Create
        public ActionResult Create()
        {
            GioiTinh gt = new GioiTinh();
            TinhTrangSinhVien tt = new TinhTrangSinhVien();
            DanToc dt = new DanToc();
            ViewBag.DanToc = new SelectList(dt.GetListDanToc(), "DanTocID", "TenDanToc");
            ViewBag.TinhTrang = new SelectList(tt.GetListTinhTrang(), "TinhTrangID", "TenTinhTrang");
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text");
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoId", "TenNganh");
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
        public ActionResult Create(SinhVien model)
        {
            int checkMASV = db.SinhViens.Count(x => x.MaSinhVien.Equals(model.MaSinhVien));
            if (checkMASV > 0)
            {
                ModelState.AddModelError("", "Mã sinh viên đã tồn tại");
                return View(model);
            };
            GioiTinh gt = new GioiTinh();
            TinhTrangSinhVien tt = new TinhTrangSinhVien();
            DanToc dt = new DanToc();
            ViewBag.DanToc = new SelectList(dt.GetListDanToc(), "DanTocID", "TenDanToc");
            ViewBag.TinhTrang = new SelectList(tt.GetListTinhTrang(), "TinhTrangID", "TenTinhTrang");
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text");
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoId", "TenNganh");
            db.SinhViens.Add(model);
            db.SaveChanges();
            return View(model);
        }

        // GET: SinhVien/Edit/5
        public ActionResult Edit(int? id)
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
            GioiTinh gt = new GioiTinh();
            TinhTrangSinhVien tt = new TinhTrangSinhVien();
            DanToc dt = new DanToc();
            ViewBag.DanToc = new SelectList(dt.GetListDanToc(), "DanTocID", "TenDanToc", sinhVien.DanToc);
            ViewBag.TinhTrang = new SelectList(tt.GetListTinhTrang(), "TinhTrangID", "TenTinhTrang", sinhVien.TinhTrang);
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text", sinhVien.GioiTinh);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", sinhVien.KhoaID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoId", "TenNganh", sinhVien.NganhDaoTaoID);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(SinhVien sinhVien)
        {
           try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                GioiTinh gt = new GioiTinh();
                TinhTrangSinhVien tt = new TinhTrangSinhVien();
                DanToc dt = new DanToc();
                ViewBag.DanToc = new SelectList(dt.GetListDanToc(), "DanTocID", "TenDanToc", sinhVien.DanToc);
                ViewBag.TinhTrang = new SelectList(tt.GetListTinhTrang(), "TinhTrangID", "TenTinhTrang", sinhVien.TinhTrang);
                ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text", sinhVien.GioiTinh);
                ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", sinhVien.NganhDaoTaoID);
                ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", sinhVien.KhoaID);
                return View(sinhVien);
            }
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if(sinhVien == null)
            {
                return HttpNotFound();
            }
            GioiTinh gt = new GioiTinh();
            TinhTrangSinhVien tt = new TinhTrangSinhVien();
            DanToc dt = new DanToc();
            ViewBag.DanToc = new SelectList(dt.GetListDanToc(), "DanTocID", "TenDanToc", sinhVien.DanToc);
            ViewBag.TinhTrang = new SelectList(tt.GetListTinhTrang(), "TinhTrangID", "TenTinhTrang", sinhVien.TinhTrang);
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text", sinhVien.GioiTinh);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", sinhVien.KhoaID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoId", "TenNganh", sinhVien.NganhDaoTaoID);
            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SinhVien sinhVien = db.SinhViens.Find(id);
                db.SinhViens.Remove(sinhVien);
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
