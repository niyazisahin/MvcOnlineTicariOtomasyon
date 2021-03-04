using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class DinamikFaturalarClass
    {
        public IEnumerable<Fatura> fatura { get; set; }
        public IEnumerable<FaturaKalem> faturaKalem { get; set; }
    }
}