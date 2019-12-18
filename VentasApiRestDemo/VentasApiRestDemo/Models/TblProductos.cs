using System;
using System.Collections.Generic;

namespace VentasApiRestDemo.Models
{
    public partial class TblProductos
    {
        public string CodProd { get; set; }
        public string NomProd { get; set; }
        public string CodGrup { get; set; }
        public string CodLin { get; set; }
        public string Marca { get; set; }
        public decimal CosPromC { get; set; }
        public decimal? PrecioVta { get; set; }

        public virtual TblGrupos CodGrupNavigation { get; set; }
        public virtual TblLineas CodLinNavigation { get; set; }
    }
}
