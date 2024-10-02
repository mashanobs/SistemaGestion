using System;
using System.Collections.Generic;
using System.Linq;
using SistemaGestionData.Contexts;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess
{
    public class VentaDataAccess
    {
        private readonly MyDbContext _context;

        public VentaDataAccess()
        {
            _context = new MyDbContext();
        }

        public List<Venta> GetVentas()
        {
            try
            {
                return _context.Venta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de ventas", ex);
            }
        }

        public Venta? GetOneVenta(int id)
        {
            try
            {
                return _context.Venta.FirstOrDefault(v => v.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la venta con ID {id}", ex);
            }
        }

        public int InsertVenta(Venta venta)
        {
            try
            {
                _context.Venta.Add(venta);
                _context.SaveChanges();
                return venta.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar una venta", ex);
            }
        }

        public void UpdateVenta(int id, Venta venta)
        {
            try
            {
                var existing = _context.Venta.FirstOrDefault(v => v.Id == id);
                if (existing != null)
                {
                    existing.Comentarios = venta.Comentarios;
                    existing.IdUsuario = venta.IdUsuario;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la venta con ID {id}", ex);
            }
        }

        public void DeleteVenta(int id)
        {
            try
            {
                var venta = _context.Venta.FirstOrDefault(v => v.Id == id);
                if (venta != null)
                {
                    _context.Venta.Remove(venta);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la venta con ID {id}", ex);
            }
        }
    }
}
