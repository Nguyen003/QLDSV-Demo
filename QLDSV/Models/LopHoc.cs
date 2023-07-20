namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHoc")]
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHoc()
        {
            Lop_SinhVien = new HashSet<Lop_SinhVien>();
        }

        public int LopHocID { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        public int? KhoaID { get; set; }

        public int? KhoaHocID { get; set; }

        public int? GiangVienID { get; set; }

        public virtual Khoa Khoa { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lop_SinhVien> Lop_SinhVien { get; set; }
    }
}
