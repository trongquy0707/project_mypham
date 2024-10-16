using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_my_pham.Data
{
    [Table("CHUC_VU")]
    public class CHUC_VU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public virtual ICollection<TAI_KHOAN> TAI_KHOAN { get; set; }
      
    }
}
