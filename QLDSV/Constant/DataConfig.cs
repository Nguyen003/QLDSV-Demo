using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDSV.Constant
{
    public class DataConfig
    {
    }

    public class GioiTinh
    {
        public bool Value { get; set; }
        public string Text { get; set; }

        public GioiTinh()
        {

        }
        public List<GioiTinh> GetListGioiTinh()
        {
            List<GioiTinh> data = new List<GioiTinh>();
            data.Add(new GioiTinh() { Text = "Nam", Value = true });
            data.Add(new GioiTinh() { Text = "Nữ", Value = false });
            return data;
        }
    }

    public class KichHoatLopTinChi
    {
        public bool Value { get; set; }
        public string Text { get; set; }
        public KichHoatLopTinChi() { }
        public List<KichHoatLopTinChi> GetListLopTinChi()
        {
            List<KichHoatLopTinChi> data = new List<KichHoatLopTinChi>();
            data.Add(new KichHoatLopTinChi() { Text = "Mở Lớp", Value = true });
            data.Add(new KichHoatLopTinChi() { Text = "Đóng Lớp", Value = false });
            return data;
        }
    }

    public class TinhTrangSinhVien
    {
        public int TinhTrangID { get; set; }
        public string TenTinhTrang { get; set; }
        public TinhTrangSinhVien() { }
        public List<TinhTrangSinhVien> GetListTinhTrang()
        {
            List<TinhTrangSinhVien> data = new List<TinhTrangSinhVien>();
            data.Add(new TinhTrangSinhVien() { TenTinhTrang = "Còn Học", TinhTrangID = 1 });
            data.Add(new TinhTrangSinhVien() { TenTinhTrang = "Nghỉ Hoc", TinhTrangID = 1 });
            data.Add(new TinhTrangSinhVien() { TenTinhTrang = "Đình chỉ hoc", TinhTrangID = 1 });
            return data;
        }
    }

    public class LoaiMonHoc
    {
        public int LoaiMonHocID { get; set; }
        public string TenLoaiMonHoc { get; set; }
        public LoaiMonHoc() { }

        public List<LoaiMonHoc> GetListLoaiMonHoc()
        {
            List<LoaiMonHoc> data = new List<LoaiMonHoc>();
            data.Add(new LoaiMonHoc() { TenLoaiMonHoc = "Bắt Buộc", LoaiMonHocID = 1 });
            data.Add(new LoaiMonHoc() { TenLoaiMonHoc = "Tự Chọn", LoaiMonHocID = 2 });
            return data;
        }
    }

    public class DanToc
    {
        public int DanTocID { get; set; }
        public string TenDanToc { get; set; }
        public DanToc() { }
        public List<DanToc> GetListDanToc()
        {
            List<DanToc> data = new List<DanToc>();
            data.Add(new DanToc() { TenDanToc = "Kinh", DanTocID = 1 });
            data.Add(new DanToc() { TenDanToc = "Chăm", DanTocID = 2 });
            data.Add(new DanToc() { TenDanToc = "Khác", DanTocID = 3 });
            return data;
        }
    }
}