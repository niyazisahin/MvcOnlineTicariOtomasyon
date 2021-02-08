using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacakID { get; set; }

        [Display(Name = "Yapilacak Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string YapilacakBaslik { get; set; }
        public bool YapilacakDurum { get; set; }

        [Display(Name = "Yapilacak Süresi")]
        public int Gun { get; set; }
    }
}