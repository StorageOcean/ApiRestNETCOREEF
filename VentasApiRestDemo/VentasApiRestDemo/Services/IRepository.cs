using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasApiRestDemo.DTO;
using VentasApiRestDemo.Models;

namespace VentasApiRestDemo.Services
{
    public interface IRepository
    {
        ResponseEntity<ProductoDTO> GetProductos();

        Task<ResponseEntity<ProductoDTO>> GetProductosAsync();

        ResponseEntity<ProductoDTO> GetProducto(ProductoDTO producto);

        ResponseEntity<ProductoDTO> PostProducto(ProductoDTO producto);

        ResponseEntity<ProductoDTO> PutProducto(ProductoDTO producto);

        ResponseEntity<ProductoDTO> DelProducto(ProductoDTO producto);
    }
}
