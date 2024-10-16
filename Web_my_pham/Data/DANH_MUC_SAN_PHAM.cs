using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("DANH_MUC_SAN_PHAM")]
    public class DANH_MUC_SAN_PHAM
    {
        public DANH_MUC_SAN_PHAM()
        {
            this.SAN_PHAM_CHI_TIET = new HashSet<SAN_PHAM_CHI_TIET>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDanhMuc { get; set; }
        public string AnhDanhMuc { get; set; }
        public string TenDangMuc { get; set; }
        public virtual ICollection<SAN_PHAM_CHI_TIET> SAN_PHAM_CHI_TIET { get; set; }
    }
}
