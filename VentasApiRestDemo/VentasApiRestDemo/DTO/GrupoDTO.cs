using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApiRestDemo.DTO
{
    public class GrupoDTO
    {
        public GrupoDTO()
        {
            ProductoDTO = new HashSet<ProductoDTO>();
        }

        public string CodGrup { get; set; }
        public string NomGrup { get; set; }

        public virtual ICollection<ProductoDTO> ProductoDTO { get; set; }
    }
}
