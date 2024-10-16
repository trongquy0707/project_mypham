using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("HINH_ANH")]
    public class HINH_ANH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHinhAnh { get; set; }
      
        [MaxLength]
        public string HinhAnh { get; set; }
        public bool? AnhChinh { get; set; }
        public int? MaSanPham { get; set; }

        [ForeignKey("MaSanPham")]
        public SAN_PHAM_CHI_TIET SAN_PHAM_CHI_TIET { get; set; }
    }
}
