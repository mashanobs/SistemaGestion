using System.Data;
using Microsoft.Data.SqlClient;
using SistemaGestionData.Contexts;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

public class ProductosDataAccess
{
    private readonly MyDbContext _context;

    public ProductosDataAccess()
    {
        _context = new MyDbContext();
    }

    public List<Producto> GetProductos()
    {
        try
        {
            return _context.Productos.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener la lista de productos", ex);
        }
    }

    public List<Producto> GetProductosBy(string filtro)
    {
        try
        {
            return _context.Productos
                .Where(producto => producto.Categoria.Contains(filtro))
                .ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener productos con el filtro '{filtro}'", ex);
        }
    }

    public Producto? GetOneProducto(int id)
    {
        try
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el producto con ID {id}", ex);
        }
    }

    public int InsertProducto(Producto producto)
    {
        try
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.Id;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar un producto", ex);
        }
    }

    public void UpdateProducto(int id, Producto producto)
    {
        try
        {
            var existing = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (existing != null)
            {
                existing.Descripcion = producto.Descripcion;
                existing.PrecioCompra = producto.PrecioCompra;
                existing.PrecioVenta = producto.PrecioVenta;
                existing.Stock = producto.Stock;
                existing.TotalProducto = producto.TotalProducto;
                existing.Categoria = producto.Categoria;
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el producto con ID {id}", ex);
        }
    }

    public void DeleteProducto(int id)
    {
        try
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el producto con ID {id}", ex);
        }
    }
}
