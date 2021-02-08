using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        [Display(Name = "Urun ID")]
        public int UrunID { get; set; }


        [Display(Name = "Urun Ad")]
        [Column(TypeName ="Varchar")]
        // [StringLength(40, ErrorMessage ="En fazla 40 karakter kullanabilirsiniz")]
        //[Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string UrunAd { get; set; }


        [Column(TypeName = "Varchar")]
        //[StringLength(40, ErrorMessage = "En fazla 40 karakter kullanabilirsiniz")]
       // [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Marka { get; set; }

        public short Stok { get; set; }
        public bool Durum { get; set; }

        [Display(Name = "Alış Fiyat")]
        public decimal AlisFiyati { get; set; }

        [Display(Name = "Satış Fiyat")]
        public decimal SatisFiyati { get; set; }

        [Display(Name = "Urun Görsel")]
        [Column(TypeName = "Varchar")]
       // [StringLength(300, ErrorMessage = "En fazla 300 karakter kullanabilirsiniz")]
      //  [Required]
        public string UrunGorsel { get; set; }

       // [Required(ErrorMessage ="Kategori kısmı boş geçilemez")]
        public int KategoryId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}