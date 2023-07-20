using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDSV.Models
{
    public class ApplicationDbContext : DbSinhVienContext
    {
        public ApplicationDbContext() : base()
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public static ApplicationDbContext context = ApplicationDbContext.Create();
        public static ApplicationDbContext GetContext()
        {
            return context ?? ApplicationDbContext.Create();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public static List<object> GetDanhSachGioiTinh()
        {
            return new List<object>(){
                new {Text = "Nam", Value = true},
                new {Text = "Nữ", Value = false}
            };
        }
    }
}