using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        [Display(Name = "Fatura ID")]
        public int FaturaId { get; set; }

        //[Column(TypeName = "Char")]
        //[StringLength(1)]
        //public char FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [Display(Name = "Fatura Sıra No")]
        public string FaturaSiraNo { get; set; }

        [Display(Name = "Fatura Tarih")]
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        [Display(Name = "Vergi Dairesi")]
        public string VergiDairesi { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string Saat { get; set; }

        [Display(Name = "Toplam Tutar")]
        public decimal ToplamTutar { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Teslim Eden")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Teslim Alan")]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}