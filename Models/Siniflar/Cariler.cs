using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        [Display(Name = "Cari ID")]
        public int CariId { get; set; }

        [Display(Name = "Cari Ad")]
        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage ="En fazla 20 karakter kullanabilirsiniz.")]
        [Required(ErrorMessage ="İsim Boş Bırakılamaz")]
        public string CariAd { get; set; }

        [Display(Name = "Cari Soyad")]
        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter kullanabilirsiniz.")]
        [Required(ErrorMessage = "İsim Boş Bırakılamaz")]
        public string CariSoyad { get; set; }

        [Display(Name = "Cari Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter kullanabilirsiniz.")]
        [Required(ErrorMessage = "ŞehirBoş Bırakılamaz")]
        public string CariSehir { get; set; }

        [Display(Name = "Cari Mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsiniz.")]
        [Required(ErrorMessage = "Mail Boş Bırakılamaz")]
        public string CariMail { get; set; }

        [Display(Name = "Cari Şifre")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsiniz.")]
        [Required(ErrorMessage = "Sifre Boş Bırakılamaz")]
        public string CariSifre { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}