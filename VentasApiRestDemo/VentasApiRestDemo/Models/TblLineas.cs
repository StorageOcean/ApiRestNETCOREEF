using System;
using System.Collections.Generic;

namespace VentasApiRestDemo.Models
{
    public partial class TblLineas
    {
        public TblLineas()
        {
            TblProductos = new HashSet<TblProductos>();
        }

        public string CodLin { get; set; }
        public string NomLin { get; set; }

        public virtual ICollection<TblProductos> TblProductos { get; set; }
    }
}
