using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasApiRestDemo.DTO;
using VentasApiRestDemo.Models;
using VentasApiRestDemo.Services;

namespace VentasApiRestDemo.Controllers
{
    [Route("api/Producto")]
    [Produces("application/json")]
    [ApiController]
    public class ProductoController : Controller
    {
        IRepository repository;

        public ProductoController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        //[HttpGet()]
        ////public ResponseEntity<ProductoDTO> GetProductos()
        //public ActionResult<ResponseEntity<ProductoDTO>> GetProductos()
        //{
        //    ResponseEntity<ProductoDTO> listado = repository.GetProductos();
        //    return listado;
        //}
        [HttpGet()]
        public async Task<ResponseEntity<ProductoDTO>> GetProductos()
        {
            ResponseEntity<ProductoDTO> listado =  await repository.GetProductosAsync();
            return listado;
        }


        [HttpGet("{id}")]
        public JsonResult GetProducto(string id)
        {
            ProductoDTO producto = new ProductoDTO
            {
                CodProd = id
            };
            ResponseEntity<ProductoDTO> listado = repository.GetProducto(producto);
            return Json(listado);
        }

        [HttpPost()]
        public JsonResult PostProducto([FromBody]ProductoDTO ProductoDTO)
        {
            ResponseEntity<ProductoDTO> listado = repository.PostProducto(ProductoDTO);
            return Json(listado);
        }

        [HttpPut("{id}")]
        public JsonResult PutProducto(string id, [FromBody]ProductoDTO ProductoDTO)
        {
            ProductoDTO productoDTO = new ProductoDTO
            {
                CodProd = id,
                NomProd = ProductoDTO.NomProd,
                CodGrup = ProductoDTO.CodGrup,
                CodLin = ProductoDTO.CodLin,
                Marca = ProductoDTO.Marca,
                CosPromC = ProductoDTO.CosPromC,
                PrecioVta = ProductoDTO.PrecioVta,
            };
            ResponseEntity<ProductoDTO> listado = repository.PutProducto(productoDTO);
            return Json(listado);
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteProducto(string id)
        {
            ProductoDTO producto = new ProductoDTO
            {
                CodProd = id
            };
            ResponseEntity<ProductoDTO> listado = repository.DelProducto(producto);
            return Json(listado);
        }
    }
}
