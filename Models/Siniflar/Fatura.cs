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
        [Required]
        public string FaturaSiraNo { get; set; }

        [Display(Name = "Fatura Tarih")]
        [Required]
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        [Display(Name = "Vergi Dairesi")]
        [Required]
        public string VergiDairesi { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        [Required]
        public string Saat { get; set; }
        

        [Display(Name = "Toplam Tutar")]
        [Required]
        public decimal ToplamTutar { get; set; }
        

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Teslim Eden")]
        [Required]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Teslim Alan")]
        [Required]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}