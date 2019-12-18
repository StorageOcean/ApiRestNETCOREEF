using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasApiRestDemo.DTO;
using VentasApiRestDemo.Models;

namespace VentasApiRestDemo.Services
{
    public class BDVentasRepository : IRepository
    {
        private readonly BDVentasContext _context;

        public BDVentasRepository(BDVentasContext context)
        {
            this._context = context;
        }

        public ResponseEntity<ProductoDTO> GetProductos()
        {

            ResponseEntity<ProductoDTO> oResponseEntity = new ResponseEntity<ProductoDTO>();
            List<ProductoDTO> listado = new List<ProductoDTO>();

            listado = _context.TblProductos.Select(x => new ProductoDTO
            {
                CodProd = x.CodProd,
                NomProd = x.NomProd,
                CodGrup = x.CodGrup,
                CodLin = x.CodLin,
                Marca = x.Marca,
                CosPromC = x.CosPromC,
                PrecioVta = x.PrecioVta,
            }).ToList();
            oResponseEntity.listEntity = listado;
            /*   oResponseEntity.listEntity.AddRange(_context.TblProductos.Select(x => new ProductoDTO
               {
                   CodProd = x.CodProd,
                   NomProd = x.NomProd,
                   CodGrup = x.CodGrup,
                   CodLin = x.CodLin,
                   Marca = x.Marca,
                   CosPromC = x.CosPromC,
                   PrecioVta = x.PrecioVta,
               }).ToList());*/
            oResponseEntity.Entity = null;
            oResponseEntity.Message = "CONSULTA CORRECTA";
            oResponseEntity.Status = true;
            oResponseEntity.Date = DateTime.Now;

            return oResponseEntity;
        }

        public async Task<ResponseEntity<ProductoDTO>> GetProductosAsync()
        {

            ResponseEntity<ProductoDTO> oResponseEntity = new ResponseEntity<ProductoDTO>();
            List<ProductoDTO> listado = new List<ProductoDTO>();

            listado = await _context.TblProductos.Select(x => new ProductoDTO
            {
                CodProd = x.CodProd,
                NomProd = x.NomProd,
                CodGrup = x.CodGrup,
                CodLin = x.CodLin,
                Marca = x.Marca,
                CosPromC = x.CosPromC,
                PrecioVta = x.PrecioVta,
            }).ToListAsync();
            oResponseEntity.listEntity = listado;
            /*   oResponseEntity.listEntity.AddRange(_context.TblProductos.Select(x => new ProductoDTO
               {
                   CodProd = x.CodProd,
                   NomProd = x.NomProd,
                   CodGrup = x.CodGrup,
                   CodLin = x.CodLin,
                   Marca = x.Marca,
                   CosPromC = x.CosPromC,
                   PrecioVta = x.PrecioVta,
               }).ToList());*/
            oResponseEntity.Entity = null;
            oResponseEntity.Message = "CONSULTA CORRECTA";
            oResponseEntity.Status = true;
            oResponseEntity.Date = DateTime.Now;

            return  oResponseEntity;
        }

        public ResponseEntity<ProductoDTO> GetProducto(ProductoDTO producto)
        {
            ResponseEntity<ProductoDTO> oResponseEntity = new ResponseEntity<ProductoDTO>();
            ProductoDTO entidad = new ProductoDTO();

            entidad = _context.TblProductos
                .Where(x => x.CodProd == producto.CodProd)
                .Select(x => new ProductoDTO
                {
                    CodProd = x.CodProd,
                    NomProd = x.NomProd,
                    CodGrup = x.CodGrup,
                    CodLin = x.CodLin,
                    Marca = x.Marca,
                    CosPromC = x.CosPromC,
                    PrecioVta = x.PrecioVta,
                }).FirstOrDefault();
            oResponseEntity.listEntity = null;

            oResponseEntity.Entity = entidad;
            oResponseEntity.Message = "CONSULTA CORRECTA";
            oResponseEntity.Status = true;
            oResponseEntity.Date = DateTime.Now;

            return oResponseEntity;
        }

        public ResponseEntity<ProductoDTO> PostProducto(ProductoDTO producto)
        {
            ResponseEntity<ProductoDTO> oResponseEntity = new ResponseEntity<ProductoDTO>();
            ProductoDTO entidad = new ProductoDTO();
            TblProductos tbl = new TblProductos();
            tbl.CodProd = producto.CodProd;
            tbl.NomProd = producto.NomProd;
            tbl.CodGrup = producto.CodGrup;
            tbl.CodLin = producto.CodLin;
            tbl.Marca = producto.Marca;
            tbl.CosPromC = producto.CosPromC;
            tbl.PrecioVta = producto.PrecioVta;
            //_context.TblProductos.Add(tbl);
            //_context.SaveChanges();

            _context.Entry(tbl).State = EntityState.Added;
            _context.SaveChanges();

            entidad = _context.TblProductos
              .Where(x => x.CodProd == producto.CodProd)
              .Select(x => new ProductoDTO
              {
                  CodProd = x.CodProd,
                  NomProd = x.NomProd,
                  CodGrup = x.CodGrup,
                  CodLin = x.CodLin,
                  Marca = x.Marca,
                  CosPromC = x.CosPromC,
                  PrecioVta = x.PrecioVta,
              }).FirstOrDefault();

            oResponseEntity.listEntity = null;

            oResponseEntity.Entity = entidad;
            oResponseEntity.Message = "INSERCCION CORRECTA";
            oResponseEntity.Status = true;
            oResponseEntity.Date = DateTime.Now;

            return oResponseEntity;
        }

        public ResponseEntity<ProductoDTO> PutProducto(ProductoDTO producto)
        {
            ResponseEntity<ProductoDTO> oResponseEntity = new ResponseEntity<ProductoDTO>();
            ProductoDTO entidad = new ProductoDTO();
            TblProductos tbl = new TblProductos();
            tbl.CodProd = producto.CodProd;
            tbl.NomProd = producto.NomProd;
            tbl.CodGrup = producto.CodGrup;
            tbl.CodLin = producto.CodLin;
            tbl.Marca = producto.Marca;
            tbl.CosPromC = producto.CosPromC;
            tbl.PrecioVta = producto.PrecioVta;
            _context.TblProductos.Update(tbl);
            _context.SaveChanges();

            entidad = _context.TblProductos
              .Where(x => x.CodProd == producto.CodProd)
              .Select(x => new ProductoDTO
              {
                  CodProd = x.CodProd,
                  NomProd = x.NomProd,
                  CodGrup = x.CodGrup,
                  CodLin = x.CodLin,
                  Marca = x.Marca,
                  CosPromC = x.CosPromC,
                  PrecioVta = x.PrecioVta,
              }).FirstOrDefault();

            oResponseEntity.listEntity = null;
            oResponseEntity.Entity = entidad;
            oResponseEntity.Message = "ACTUALIZACION CORRECTA";
            oResponseEntity.Status = true;
            oResponseEntity.Date = DateTime.Now;

            return oResponseEntity;
        }
        public ResponseEntity<ProductoDTO> DelProducto(ProductoDTO producto)
        {
            ResponseEntity<ProductoDTO> oResponseEntity = new ResponseEntity<ProductoDTO>();

            TblProductos tbl = new TblProductos();
            tbl.CodProd = producto.CodProd;
            tbl.NomProd = producto.NomProd;
            tbl.CodGrup = producto.CodGrup;
            tbl.CodLin = producto.CodLin;
            tbl.Marca = producto.Marca;
            tbl.CosPromC = producto.CosPromC;
            tbl.PrecioVta = producto.PrecioVta;
            _context.TblProductos.Remove(tbl);
            _context.SaveChanges();

            oResponseEntity.listEntity = null;
            oResponseEntity.Entity = null;
            oResponseEntity.Message = "ELIMINACION CORRECTA";
            oResponseEntity.Status = true;
            oResponseEntity.Date = DateTime.Now;

            return oResponseEntity;
        }

   
        /*Task<ResponseEntity<ProductoDTO>> IRepository.GetProductosAsync()
        {
            throw new NotImplementedException();
        }*/
    }
}
