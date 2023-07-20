namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangVien")]
    public partial class GiangVien
    {
        public int GiangVienID { get; set; }

        [StringLength(50)]
        public string MaGiangVien { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string SoCCCD { get; set; }

        [StringLength(200)]
        public string QueQuan { get; set; }

        public int? KhoaID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}
