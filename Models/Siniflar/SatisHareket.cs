using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public int Adet { get; set; }

        [Required]
        public decimal BirimFiyat { get; set; }

        [Required]
        public decimal Tutar { get; set; }

        [Required]
        public int UrunID { get; set; }

        [Required]
        public int CariId { get; set; }

        [Required]
        public int PersonelId { get; set; }
        public virtual Urun Urun { get; set; }
        public  virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}