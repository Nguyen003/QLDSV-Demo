namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonHoc")]
    public partial class MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonHoc()
        {
            LopTinChis = new HashSet<LopTinChi>();
            NganhDaoTao_MonHoc = new HashSet<NganhDaoTao_MonHoc>();
        }

        public int MonHocID { get; set; }

        [StringLength(50)]
        public string MaMonHoc { get; set; }

        [StringLength(50)]
        public string TenMonHoc { get; set; }

        public int? SoTinChi { get; set; }

        public int? LoaiMonHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopTinChi> LopTinChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NganhDaoTao_MonHoc> NganhDaoTao_MonHoc { get; set; }
    }
}
