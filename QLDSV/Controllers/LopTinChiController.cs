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

namespace QLDSV.Controllers
{
    public class LopTinChiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: LopTinChi
        public ActionResult Index()
        {
            var listLopTinChi = db.LopTinChis.ToList();
            return View(listLopTinChi);
        }

        // GET: LopTinChi/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopTinChi lopTinChi = db.LopTinChis.Find(id);
            if(lopTinChi == null)
            {
                return HttpNotFound();
            }
            var khoaID = db.NganhDaoTaos.FirstOrDefault(x => x.NganhDaoTaoID == lopTinChi.NghanhDaoTaoID).KhoaID;
            KichHoatLopTinChi kichHoat = new KichHoatLopTinChi();
            ViewBag.KichHoat = new SelectList(kichHoat.GetListLopTinChi(), "Value", "Text", lopTinChi.KichHoat);
            ViewBag.GiangVienID = new SelectList(db.GiangViens, "GiangVienID", "HoTen", lopTinChi.GiangVienID);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", khoaID);
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc", lopTinChi.MonHocID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", lopTinChi.NghanhDaoTaoID);

            var data = db.BangDiems.Join(db.SinhViens, o1 => o1.SinhVienID, o2 => o2.SinhVienID, (o1, o2) =>
                        new DanhSachLopViewModel()
                        {
                            BangDiemID = o1.BangDiemID,
                            LopTinChiID = (int)o1.LopTinChiID,
                            SinhVienID = (int)o1.SinhVienID,
                            MaSinhVien = o2.MaSinhVien,
                            HoTen = o2.HoTen,
                            NgaySinh = o2.NgaySinh,
                            DiemThanhPhan = (double?)o1.DiemThanhPhan,
                            DiemThi = (double?)o1.DiemThi,
                            DiemChu = o1.DiemChu,
                            DiemTrungBinh = ((double?)o1.DiemThanhPhan * 0.3) + ((double?)o1.DiemThi * 0.7)
                        })
                .Where(y => y.LopTinChiID == lopTinChi.LopTinChiID)
                .ToList();
            ViewData["dataSinhVien"] = data;
            return View(lopTinChi);
        }

        // GET: LopTinChis/Create
        public ActionResult ThemSinhVienVaoLop(int? id) 
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopTinChi lopTinChi = db.LopTinChis.Find(id);
            if(lopTinChi == null)
            {
                return HttpNotFound();
            }
            var khoaID = db.NganhDaoTaos.FirstOrDefault(x => x.NganhDaoTaoID == lopTinChi.NghanhDaoTaoID).KhoaID;
            KichHoatLopTinChi kichHoat = new KichHoatLopTinChi();
            ViewBag.KichHoat = new SelectList(kichHoat.GetListLopTinChi(), "Value", "Text", lopTinChi.KichHoat);
            ViewBag.GiangVienID = new SelectList(db.GiangViens, "GiangVienID", "HoTen", lopTinChi.GiangVienID);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", khoaID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", lopTinChi.NghanhDaoTaoID);
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc", lopTinChi.MonHocID);
            var data = db.SinhViens.Where(x => x.KhoaID == khoaID && x.TinhTrang == 1).ToList();
            ViewData["dataSinhVien"] = data;
            return View(lopTinChi);
        }

        // GET: LopTinChi/Create
        public ActionResult Create()
        {
            KichHoatLopTinChi kichHoat = new KichHoatLopTinChi();
            ViewBag.KichHoat = new SelectList(kichHoat.GetListLopTinChi(), "Value", "Text");
            ViewBag.GiangVienID = new SelectList(db.GiangViens, "GiangVienID", "HoTen");
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc");
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh");
            return View();
        }

        // POST: LopTinChi/Create
        [HttpPost]
        public ActionResult Create(LopTinChi model) 
        {
            if(ModelState.IsValid)
            {
                db.LopTinChis.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc");
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoId", "TenNganh");
            return View(model);
        }

        // GET: LopTinChi/Edit/5
        public ActionResult Edit(int id)
        {
            LopTinChi ltc = db.LopTinChis.Find(id);
            if (ltc == null)
            {
                return HttpNotFound();
            }
            var khoaID = db.NganhDaoTaos.FirstOrDefault(x => x.NganhDaoTaoID == ltc.NghanhDaoTaoID).KhoaID;
            KichHoatLopTinChi kichHoat = new KichHoatLopTinChi();
            ViewBag.KichHoat = new SelectList(kichHoat.GetListLopTinChi(), "Value", "Text", ltc.KichHoat);
            ViewBag.GiangVienID = new SelectList(db.GiangViens, "GiangVienID", "HoTen", ltc.GiangVienID);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", khoaID);
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc", ltc.MonHocID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", ltc.NghanhDaoTaoID);
            return View(ltc);
        }

        // POST: LopTinChi/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "LopTinChiID,MaLopTinChi,TenLopTinChi,SoLuongToiDa,NgayBatDau,NgayKetThuc,GiangVienID,MonHocID,NganhDaoTaoID,KichHoat")] LopTinChi ltc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ltc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var khoaID = db.NganhDaoTaos.FirstOrDefault(x => x.NganhDaoTaoID == ltc.NghanhDaoTaoID).KhoaID;
            KichHoatLopTinChi kichHoat = new KichHoatLopTinChi();
            ViewBag.KichHoat = new SelectList(kichHoat.GetListLopTinChi(), "Value", "Text", ltc.KichHoat);
            ViewBag.GiangVienID = new SelectList(db.GiangViens, "GiangVienID", "HoTen", ltc.GiangVienID);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", khoaID);
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc", ltc.MonHocID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", ltc.NghanhDaoTaoID);
            return View(ltc);
        }

        // GET: LopTinChi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopTinChi lopTinChi = db.LopTinChis.Find(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            var khoaID = db.NganhDaoTaos.FirstOrDefault(x => x.NganhDaoTaoID == lopTinChi.NghanhDaoTaoID).KhoaID;
            KichHoatLopTinChi ltc = new KichHoatLopTinChi();
            ViewBag.KichHoat = new SelectList(ltc.GetListLopTinChi(), "Value", "Text", lopTinChi.KichHoat);
            ViewBag.GiangVienID = new SelectList(db.GiangViens, "GiangVienID", "HoTen", lopTinChi.GiangVienID);
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa", khoaID);
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc", lopTinChi.MonHocID);
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh", lopTinChi.NghanhDaoTaoID);
            return View(lopTinChi);
        }

        // POST: LopTinChi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            LopTinChi lopTinChi = db.LopTinChis.Find(id);
            db.LopTinChis.Remove(lopTinChi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
