using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        [Display(Name = "Departman ID")]
        public int DepartmanId { get; set; }

        [Display(Name = "Departman Ad")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter kullanabilirsiniz")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string DepartmanAd { get; set; }
        [Display(Name = "Departman Durum")]
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}