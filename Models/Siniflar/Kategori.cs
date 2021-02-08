using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        [Display(Name = "Kategori ID")]
        public int KategoryId { get; set; }

        [Display(Name = "Kategori Ad")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter kullanabilirsiniz")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}