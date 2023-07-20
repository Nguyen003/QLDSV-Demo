namespace QLDSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NganhDaoTao")]
    public partial class NganhDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganhDaoTao()
        {
            LopTinChis = new HashSet<LopTinChi>();
            NganhDaoTao_MonHoc = new HashSet<NganhDaoTao_MonHoc>();
        }

        public int NganhDaoTaoID { get; set; }

        [StringLength(50)]
        public string TenNganh { get; set; }

        public int? KhoaID { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopTinChi> LopTinChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NganhDaoTao_MonHoc> NganhDaoTao_MonHoc { get; set; }
    }
}
