using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApiRestDemo.DTO
{
    public class LineaDTO
    {
        public LineaDTO()
        {
            ProductoDTO = new HashSet<ProductoDTO>();
        }

        public string CodLin { get; set; }
        public string NomLin { get; set; }

        public virtual ICollection<ProductoDTO> ProductoDTO { get; set; }
    }
}
