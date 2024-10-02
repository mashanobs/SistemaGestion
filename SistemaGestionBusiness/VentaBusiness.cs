using SistemaGestionData.DataAccess;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionBusiness
{
    public class VentaBusiness
    {
        private VentaDataAccess _ventaDataAccess;

        public VentaBusiness(VentaDataAccess ventaDataAccess)
        {
            _ventaDataAccess = ventaDataAccess;
        }

        public List<Venta> GetVentas()
        {
            return _ventaDataAccess.GetVentas();
        }

        public Venta? GetOneVenta(int id)
        {
            return _ventaDataAccess.GetOneVenta(id);
        }

        public void InsertVenta(Venta venta)
        {
            _ventaDataAccess.InsertVenta(venta);
        }

        public void UpdateVenta(int id, Venta venta)
        {
            _ventaDataAccess.UpdateVenta(id, venta);
        }

        public void DeleteVenta(int id)
        {
            _ventaDataAccess.DeleteVenta(id);
        }
    }
}
