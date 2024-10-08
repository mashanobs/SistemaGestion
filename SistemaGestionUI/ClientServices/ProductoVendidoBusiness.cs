using Microsoft.AspNetCore.WebUtilities;
using SistemaGestionEntities;
using System.Net.Http.Json;

namespace SistemaGestionUI.ClientServices
{
    public class ProductoVendidoBusiness
    {
        private readonly HttpClient _httpClient;

        public ProductoVendidoBusiness(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductoVendido>?> GetProductoVendidos()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductoVendido>>("");
        }

        public async Task<ProductoVendido?> GetOneProductoVendido(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductoVendido>($"{id}");
        }

        public async Task InsertProductoVendido(ProductoVendido productoVendido)
        {
            await _httpClient.PostAsJsonAsync("", productoVendido);
        }

        public async Task UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            await _httpClient.PutAsJsonAsync($"{id}", productoVendido);
        }

        public async Task DeleteProductoVendido(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }
    }
}
