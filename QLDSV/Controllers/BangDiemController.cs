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
    public class BangDiemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: BangDiem
        public ActionResult Index()
        {
            var listBangDiem = db.BangDiems.ToList();
            ViewBag.LopTinChiID = new SelectList(db.LopTinChis, "LopTinChiID", "TenLopTinChi");
            ViewBag.KhoaID = new SelectList(db.Khoas, "KhoaID", "TenKhoa");
            ViewBag.MonHocID = new SelectList(db.MonHocs, "MonHocID", "TenMonHoc");
            ViewBag.NganhDaoTaoID = new SelectList(db.NganhDaoTaos, "NganhDaoTaoID", "TenNganh");
            return View(listBangDiem);
        }

        public ActionResult GiangVienCapNhatDiem(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.BangDiems
                .Join(db.SinhViens, o1 => o1.SinhVienID, o2 => o2.SinhVienID, (o1, o2) => 
                    new DanhSachLopViewModel()
                    {
                        BangDiemID = o1.BangDiemID,
                        LopTinChiID = (int)o1.LopTinChiID,
                        SinhVienID = o2.SinhVienID,
                        HoTen = o2.HoTen,
                        NgaySinh = o2.NgaySinh,
                        DiemThanhPhan = (double)o1.DiemThanhPhan,
                        DiemThi = (double)o1.DiemThi,
                        DiemTrungBinh = ((double)o1.DiemThanhPhan * 0.3) + ((double)o1.DiemThi * 0.7),
                        DiemChu = o1.DiemChu
                    })
                .Where(l => l.LopTinChiID == id)
                .ToList();
                    
            return View();
        }

        public ActionResult BangDiemSinhVien(int? id)
        {
            BangDiem bangDiem = db.BangDiems.Find(id);
            List<BangDiemMonHocViewModel> model = db.BangDiems
                       .Join(db.LopTinChis, l => l.LopTinChiID, l2 => l2.LopTinChiID, (l, l2) => new { l, l2 })
                       .Join(db.MonHocs, m => m.l2.MonHocID, m2 => m2.MonHocID, (m, m2) => new BangDiemMonHocViewModel()
                       {
                           SinhVienID = (int)m.l.SinhVienID
                              ,
                           TenMonHoc = m2.TenMonHoc
                              ,
                           SoTinChi = m2.SoTinChi
                              ,
                           DiemThanhPhan = (double)m.l.DiemThanhPhan
                              ,
                           DiemThi = (double)m.l.DiemThi
                              ,
                           DiemTrungBinh = ((double)m.l.DiemThanhPhan * 0.3) + ((double)m.l.DiemThi * 0.7)
                              ,
                           DiemChu = m.l.DiemChu
                       })
                       .Where(x => x.SinhVienID == bangDiem.SinhVienID)
                       .ToList();

            return View(model);
        }

        public JsonResult LayDanhSachBangDiemTheoLopTinChi(int loptinchiID)
        {
            var data = db.BangDiems
                .Join(db.SinhViens, o1 => o1.SinhVienID, o2 => o2.SinhVienID, (o1, o2) =>
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
                        DiemTrungBinh = ((double?)o1.DiemThanhPhan * 0.3) + ((double?)o1.DiemThi * 0.7),
                        DiemChu = o1.DiemChu

                    })
                .Where(x => x.LopTinChiID == loptinchiID).ToList();
            var json = Json(data, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        // GET: BangDiem/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangDiem bangDiem = db.BangDiems.Find(id);
            if(bangDiem == null)
            {
                return HttpNotFound();
            }
            return View(bangDiem);
        }

        // GET: BangDiem/Create
        public ActionResult Create()
        {
            ViewBag.LopTinChiID = new SelectList(db.LopTinChis, "LopTinChiID", "TenLopTinChi");
            return View();
        }

        // POST: BangDiem/Create
        [HttpPost]
        public ActionResult Create(BangDiem model)
        {
            if(ModelState.IsValid)
            {
                db.BangDiems.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: BangDiem/Edit/5
        public ActionResult Edit(int id)
        {
            BangDiem bd = db.BangDiems.Find(id);
            if(bd == null)
            {
                return HttpNotFound();
            }
            ViewBag.LopTinChiID = new SelectList(db.LopTinChis, "LopTinChiID", "TenLopTinChi", bd.LopTinChiID);
            return View(bd);
        }

        // POST: BangDiem/Edit/5
        [HttpPost]
        public ActionResult Edit(BangDiem model)
        {
            if(ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LopTinChiID = new SelectList(db.LopTinChis, "LopTinChiID", "TenLopTinChi", model.LopTinChiID);
            return View(model);
        }

        // GET: BangDiem/Delete/5
        public ActionResult Delete(int id)
        {
            BangDiem bd = db.BangDiems.Find(id);
            if (bd == null)
            {
                return HttpNotFound();
            }
            return View(bd);
        }

        // POST: BangDiem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BangDiem bd = db.BangDiems.Find(id);
                db.BangDiems.Remove(bd);
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
