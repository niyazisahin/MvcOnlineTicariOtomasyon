using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        [Display(Name = "Personel ID")]
        public virtual int PersonelId { get; set; }

        [Display(Name ="Personel Ad")]
        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage ="En fazla 25 karakter kullanabilirsiniz")]
        [Required(ErrorMessage ="İsim alanı boş bırakılamaz")]
        public string PersonelAd { get; set; }

        [Display(Name = "Personel Soyad")]
        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage = "En fazla 25 karakter kullanabilirsiniz")]
        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz")]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [Display(Name = "Personel Görsel")]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        [Required]
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}