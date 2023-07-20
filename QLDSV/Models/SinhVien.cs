namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            Lop_SinhVien = new HashSet<Lop_SinhVien>();
            LopTinChi_SinhVien = new HashSet<LopTinChi_SinhVien>();
        }

        public int SinhVienID { get; set; }

        [StringLength(50)]
        public string MaSinhVien { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        public int? DanToc { get; set; }

        public int? SoCCCD { get; set; }

        public int? TinhTrang { get; set; }

        public int? Sđt { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public int? KhoaID { get; set; }

        public int? NganhDaoTaoID { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lop_SinhVien> Lop_SinhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopTinChi_SinhVien> LopTinChi_SinhVien { get; set; }
    }
}
