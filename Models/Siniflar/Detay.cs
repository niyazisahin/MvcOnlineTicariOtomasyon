using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsiniz")]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000, ErrorMessage = "En fazla 2000 karakter kullanabilirsiniz")]
        public string UrunBilgi{ get; set; }
    }
}