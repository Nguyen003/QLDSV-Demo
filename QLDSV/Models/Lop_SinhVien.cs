namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lop_SinhVien
    {
        public int ID { get; set; }

        public int? LopHocID { get; set; }

        public int? SinhVienID { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
