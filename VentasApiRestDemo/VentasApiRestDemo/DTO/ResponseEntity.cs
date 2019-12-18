using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApiRestDemo.DTO
{
    public class ResponseEntity<T> 
    {
        public List<T> listEntity { get; set; } // DEVUELVE LISTADO ENTIDADES
        public T Entity { get; set; } // DEVUELVE SOLO UNA ENTIDAD
        public string Message { set; get; }
        public bool Status { set; get; }
        public DateTime Date { set; get; }
    }
}
