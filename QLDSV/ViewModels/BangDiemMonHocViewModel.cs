using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDSV.ViewModels
{
    public class BangDiemMonHocViewModel
    {
        public int SinhVienID { get; set; }
        public string TenMonHoc { get; set; }
        public int? SoTinChi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = true)]
        public double? DiemThanhPhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = true)]
        public double? DiemThi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = true)]
        public double? DiemTrungBinh { get; set; }
        public string DiemChu { get; set; }
    }
}