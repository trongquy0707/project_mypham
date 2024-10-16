using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("HOA_DON")]
    public class HOA_DON
    {
        public HOA_DON()
        {
            this.HOA_DON_CHI_TIET = new HashSet<HOA_DON_CHI_TIET>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHD { get; set; }
        public DateTime NgayMua { get; set; }
        public float? TongTien { get; set; }
        [MaxLength]
        public string TenKhachHang { get; set; }    
        [MaxLength]
        public string Code { get; set; }
        [StringLength(80)]
        public string ThanhPho { get; set; }
        [StringLength(80)]
        public string Quan_Huyen { get; set; }
        [StringLength(80)]
        public string Xa_Phuong { get; set; }
        [MaxLength]
        public string Ghi_Chu { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        public int? Thanh_Toan { get; set; }
        public int? SoLuong { get; set; }
        public string SoDienThoai { get; set; }
        public int? Status { get; set; }
        public virtual ICollection<HOA_DON_CHI_TIET> HOA_DON_CHI_TIET { get; set; }


    }
}
