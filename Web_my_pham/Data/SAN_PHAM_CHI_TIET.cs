using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("SAN_PHAM_CHI_TIET")]
    public class SAN_PHAM_CHI_TIET
    {
        public SAN_PHAM_CHI_TIET()
        {
           
            this.HINH_ANH = new HashSet<HINH_ANH>();
            this.HOA_DON_CHI_TIET = new HashSet<HOA_DON_CHI_TIET>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSP { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnhChinh { get; set; }
        public float? GiaGoc { get; set; }
        public float? GiaSale { get; set; }
        [MaxLength]
        public string MoTaChiTiet { get; set; }
        public float? PhanTramSale { get; set; }
        public bool isSale { get; set; }
        public bool isHome { get; set; }
        public int? TrangThai { get; set; }

        public int? MaDanhMuc { get; set; }

        [ForeignKey("MaDanhMuc")]   
        public virtual DANH_MUC_SAN_PHAM DANH_MUC_SAN_PHAM { get; set; }
        public virtual ICollection<HOA_DON_CHI_TIET> HOA_DON_CHI_TIET { get; set; }
        public virtual ICollection<HINH_ANH> HINH_ANH { get; set; }


    }
}
