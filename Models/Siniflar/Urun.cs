using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
//using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
   
    public class Urun
    {
        [Key]
        [Display(Name = "Urun ID")]
        public int UrunID { get; set; }


        [Required]
        [Display(Name = "Urun Ad")]
        [Column(TypeName ="Varchar")]
        [StringLength(40, ErrorMessage = "En fazla 40 karakter kullanabilirsiniz")]
        public string UrunAd { get; set; }


        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(40, ErrorMessage = "En fazla 40 karakter kullanabilirsiniz")]
        public string Marka { get; set; }


        [Required]
        public short Stok { get; set; }

        [Required]
        public bool Durum { get; set; }

        [Required]
        [Display(Name = "Alış Fiyat")]
        public decimal AlisFiyati { get; set; }


        [Required]
        [Display(Name = "Satış Fiyat")]
        public decimal SatisFiyati { get; set; }

        [Required]
        [Display(Name = "Urun Görsel")]
        [Column(TypeName = "Varchar")]
        public string UrunGorsel { get; set; }

        [Required]
        [Display(Name ="Kategori ID")]
        public int KategoryId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}