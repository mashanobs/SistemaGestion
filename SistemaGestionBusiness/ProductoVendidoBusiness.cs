using SistemaGestionData.DataAccess;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionBusiness
{
    public class ProductoVendidoBusiness
    {
        private readonly ProductoVendidoDataAccess _productoVendidoDataAccess;

        public ProductoVendidoBusiness(ProductoVendidoDataAccess productoVendidoDataAccess)
        {
            _productoVendidoDataAccess = productoVendidoDataAccess;
        }

        public List<ProductoVendido> GetProductoVendidos()
        {
            return _productoVendidoDataAccess.GetProductoVendidos();
        }

        public ProductoVendido? GetOneProductoVendido(int id)
        {
            return _productoVendidoDataAccess.GetOneProductoVendido(id);
        }

        public void InsertProductoVendido(ProductoVendido productoVendido)
        {
            _productoVendidoDataAccess.InsertProductoVendido(productoVendido);
        }

        public void UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            _productoVendidoDataAccess.UpdateProductoVendido(id, productoVendido);
        }

        public void DeleteProductoVendido(int id)
        {
            _productoVendidoDataAccess.DeleteProductoVendido(id);
        }
    }
}
