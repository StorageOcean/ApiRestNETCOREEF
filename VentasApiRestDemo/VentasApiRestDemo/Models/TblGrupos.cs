using System;
using System.Collections.Generic;

namespace VentasApiRestDemo.Models
{
    public partial class TblGrupos
    {
        public TblGrupos()
        {
            TblProductos = new HashSet<TblProductos>();
        }

        public string CodGrup { get; set; }
        public string NomGrup { get; set; }

        public virtual ICollection<TblProductos> TblProductos { get; set; }
    }
}
