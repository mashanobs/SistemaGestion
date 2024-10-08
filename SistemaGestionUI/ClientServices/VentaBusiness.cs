using Microsoft.AspNetCore.WebUtilities;
using SistemaGestionEntities;
using System.Net.Http.Json;

namespace SistemaGestionUI.ClientServices
{
    public class VentaBusiness
    {
        private readonly HttpClient _httpClient;

        public VentaBusiness(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Venta>?> GetVentas()
        {
            return await _httpClient.GetFromJsonAsync<List<Venta>>("");
        }

        public async Task<Venta?> GetOneVenta(int id)
        {
            return await _httpClient.GetFromJsonAsync<Venta>($"{id}");
        }

        public async Task InsertVenta(Venta venta)
        {
            await _httpClient.PostAsJsonAsync("", venta);
        }

        public async Task UpdateVenta(int id, Venta venta)
        {
            await _httpClient.PutAsJsonAsync($"{id}", venta);
        }

        public async Task DeleteVenta(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }

    }
}
