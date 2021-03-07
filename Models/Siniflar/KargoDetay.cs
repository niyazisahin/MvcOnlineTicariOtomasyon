using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        [Required]
        public string Aciklama { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string KargoTakipKodu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        [Required]
        public string GonderenPersonel { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        [Required]
        public string AliciCari { get; set; }
        public DateTime Tarih { get; set; }
    }
}