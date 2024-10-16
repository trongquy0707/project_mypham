using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("TAI_KHOAN")]
    public class TAI_KHOAN 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaUser { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public int MaChucVu { get; set; }

        [ForeignKey("MaChucVu")]
        public virtual CHUC_VU CHUC_VU { get; set; }

    }
}
