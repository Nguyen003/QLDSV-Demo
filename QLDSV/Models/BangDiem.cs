namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDiem")]
    public partial class BangDiem
    {
        public int BangDiemID { get; set; }

        public int? SinhVienID { get; set; }

        public int? LopTinChiID { get; set; }

        public decimal? DiemThanhPhan { get; set; }

        public decimal? DiemThi { get; set; }

        public decimal? DiemTrungBinh { get; set; }

        [StringLength(3)]
        public string DiemChu { get; set; }

        public virtual LopTinChi LopTinChi { get; set; }
    }
}
