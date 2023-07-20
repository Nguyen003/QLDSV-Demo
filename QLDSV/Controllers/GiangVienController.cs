using PagedList;
using QLDSV.Constant;
using QLDSV.Models;
using QLDSV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDSV.Controllers
{
    public class GiangVienController : Controller
    {
        private DbSinhVienContext db = new DbSinhVienContext();
        // GET: GiangVien
        public ActionResult Index(int? page, string search)
        {
            var sinhVien = from l in db.GiangViens select l;
            if (!String.IsNullOrEmpty(search))
            {
                sinhVien = sinhVien.Where(s => s.HoTen.Contains(search));
            }

            if (search != null) page = 1;
            var sinhvien = sinhVien.OrderBy(b => b.HoTen);
            var pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(sinhvien.ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult GetLopOfGiangVien()
        //{
        //    int id = int.Parse(Session["UserID"].ToString());

        //    List<LopTinChiMonHocViewModel> model = db.MonHocs
        //               .Join(db.LopTinChis, l => l.MonHocID, l2 => l2.MonHocID, (l, l2) => new LopTinChiMonHocViewModel
        //               {
        //                   GiangVienID = l2.GiangVienID
        //                   ,
        //                   LopTinChiID = l2.LopTinChiID
        //                   ,
        //                   MaLopTinChi = l2.MaLopTinChi
        //                   ,
        //                   TenLopTinChi = l2.TenLopTinChi
        //                   ,
        //                   TenMonHoc = l.TenMonHoc
        //                   ,
        //                   SoTinChi = l.SoTinChi
        //                   ,
        //                   NgayBatDau = l2.NgayBatDau
        //                   ,
        //                   NgayKetThuc = l2.NgayKetThuc
        //               }).Where(x => x.GiangVienID == id)
        //               .OrderByDescending(x => x.NgayBatDau)
        //               .ToList();

        //    return View(model);
        //}

        // GET: GiangVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GiangVien/Create
        public ActionResult Create()
        {
            GioiTinh gt = new GioiTinh();
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text");
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
            return View();
        }

        // POST: GiangVien/Create
        [HttpPost]
        public ActionResult Create(GiangVien model)
        {
            try
            {
                // TODO: Add insert logic here
                model.NgayTao = DateTime.Now;
                db.GiangViens.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                GioiTinh gt = new GioiTinh();
                ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text");
                ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
                return View(model);
            }
        }

        // GET: GiangVien/Edit/5
        public ActionResult Edit(int id)
        {
            GiangVien giangVien = db.GiangViens.Find(id);
            GioiTinh gt = new GioiTinh();
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text", giangVien.GioiTinh);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", giangVien.KhoaID);
            return View(giangVien);
        }

        // POST: GiangVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                GiangVien giangVien = db.GiangViens.Find(id);
                GioiTinh gt = new GioiTinh();
                ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text", giangVien.GioiTinh);
                ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", giangVien.KhoaID);
                return View(giangVien);
            }
        }

        // GET: GiangVien/Delete/5
        public ActionResult Delete(int id)
        {
            GiangVien giangVien = db.GiangViens.Find(id);
            GioiTinh gt = new GioiTinh();
            ViewBag.GioiTinh = new SelectList(gt.GetListGioiTinh(), "Value", "Text", giangVien.GioiTinh);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", giangVien.KhoaID);
            return View(giangVien);
        }

        // POST: GiangVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GiangVien giangVien = db.GiangViens.Find(id);
                db.GiangViens.Remove(giangVien);
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
