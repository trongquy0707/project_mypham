using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web_my_pham.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }
        #region
        public DbSet<TAI_KHOAN> TAI_KHOAN { get; set; }
        public DbSet<CHUC_VU> CHUC_VU { get; set; }
        public DbSet<DANH_MUC_SAN_PHAM> DANH_MUC_SAN_PHAM { get; set; }
        public DbSet<SAN_PHAM_CHI_TIET> SAN_PHAM_CHI_TIET { get; set; }
        public DbSet<HINH_ANH> HINH_ANH { get; set; }
        public DbSet<HOA_DON> HOA_DON { get; set; }
        public DbSet<HOA_DON_CHI_TIET> HOA_DON_CHI_TIET { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
