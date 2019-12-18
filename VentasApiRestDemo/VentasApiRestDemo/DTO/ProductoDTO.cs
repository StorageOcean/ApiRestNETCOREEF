using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApiRestDemo.DTO
{
    public class ProductoDTO
    {
        public string CodProd { get; set; }
        public string NomProd { get; set; }
        public string CodGrup { get; set; }
        public string CodLin { get; set; }
        public string Marca { get; set; }
        public decimal CosPromC { get; set; }
        public decimal? PrecioVta { get; set; }

        public virtual GrupoDTO CodGrupNavigation { get; set; }
        public virtual LineaDTO CodLinNavigation { get; set; }
    }
}
