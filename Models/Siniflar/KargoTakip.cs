using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string KargoTakipKodu { get; set; }

        [StringLength(250)]
        [Column(TypeName = "VarChar")]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}