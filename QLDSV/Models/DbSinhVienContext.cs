using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLDSV.Models
{
    public partial class DbSinhVienContext : DbContext
    {
        public DbSinhVienContext()
            : base("name=DbSinhVienConnectString")
        {
        }

        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<Lop_SinhVien> Lop_SinhVien { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<LopTinChi> LopTinChis { get; set; }
        public virtual DbSet<LopTinChi_SinhVien> LopTinChi_SinhVien { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NganhDaoTao> NganhDaoTaos { get; set; }
        public virtual DbSet<NganhDaoTao_MonHoc> NganhDaoTao_MonHoc { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemThanhPhan)
                .HasPrecision(18, 1);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemThi)
                .HasPrecision(18, 1);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemTrungBinh)
                .HasPrecision(18, 1);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemChu)
                .HasMaxLength(3);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.MaGiangVien)
                .IsUnicode(false);

            modelBuilder.Entity<NganhDaoTao>()
                .HasMany(e => e.LopTinChis)
                .WithOptional(e => e.NganhDaoTao)
                .HasForeignKey(e => e.NghanhDaoTaoID);
        }

    }
}
