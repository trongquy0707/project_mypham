using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("HOA_DON_CHI_TIET")]
    public class HOA_DON_CHI_TIET
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHDCT { get; set; }
        public int? SoLuongMua { get; set; }
        public float? GiaBan { get; set; }
       
        public int? MaHD { get; set; }
        [ForeignKey("MaHD")]
        public virtual HOA_DON HOA_DON { get; set; }
        public int? MaSP { get; set; }
        [ForeignKey("MaSP")]
        public virtual SAN_PHAM_CHI_TIET SAN_PHAM_CHI_TIET { get; set; }
    }
}
