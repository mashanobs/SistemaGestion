using System;
using System.Collections.Generic;
using System.Linq;
using SistemaGestionData.Contexts;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess
{
    public class ProductoVendidoDataAccess
    {
        private readonly MyDbContext _context;

        public ProductoVendidoDataAccess()
        {
            _context = new MyDbContext();
        }

        public List<ProductoVendido> GetProductoVendidos()
        {
            try
            {
                return _context.ProductoVendido.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de productos vendidos", ex);
            }
        }

        public ProductoVendido? GetOneProductoVendido(int id)
        {
            try
            {
                return _context.ProductoVendido.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el producto vendido con ID {id}", ex);
            }
        }

        public int InsertProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                _context.ProductoVendido.Add(productoVendido);
                _context.SaveChanges();
                return productoVendido.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar un producto vendido", ex);
            }
        }

        public void UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            try
            {
                var existing = _context.ProductoVendido.FirstOrDefault(p => p.Id == id);
                if (existing != null)
                {
                    existing.IdProducto = productoVendido.IdProducto;
                    existing.Stock = productoVendido.Stock;
                    existing.IdVenta = productoVendido.IdVenta;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el producto vendido con ID {id}", ex);
            }
        }

        public void DeleteProductoVendido(int id)
        {
            try
            {
                var productoVendido = _context.ProductoVendido.FirstOrDefault(p => p.Id == id);
                if (productoVendido != null)
                {
                    _context.ProductoVendido.Remove(productoVendido);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto vendido con ID {id}", ex);
            }
        }
    }
}
