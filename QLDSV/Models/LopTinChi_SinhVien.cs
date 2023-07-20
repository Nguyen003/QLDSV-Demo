namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LopTinChi_SinhVien
    {
        public int ID { get; set; }

        public int? LopTinChiID { get; set; }

        public int? SinhVienID { get; set; }

        public virtual LopTinChi LopTinChi { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
