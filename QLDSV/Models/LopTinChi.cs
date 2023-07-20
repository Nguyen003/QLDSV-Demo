namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopTinChi")]
    public partial class LopTinChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopTinChi()
        {
            BangDiems = new HashSet<BangDiem>();
            LopTinChi_SinhVien = new HashSet<LopTinChi_SinhVien>();
        }

        public int LopTinChiID { get; set; }

        [StringLength(50)]
        public string MaLopTinChi { get; set; }

        [StringLength(50)]
        public string TenLopTinChi { get; set; }

        public int? SoLuongToiDa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        public int? GiangVienID { get; set; }

        public int? MonHocID { get; set; }

        public int? NghanhDaoTaoID { get; set; }

        public bool KichHoat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        public virtual MonHoc MonHoc { get; set; }

        public virtual NganhDaoTao NganhDaoTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopTinChi_SinhVien> LopTinChi_SinhVien { get; set; }
    }
}
