using Microsoft.AspNetCore.WebUtilities;
using SistemaGestionEntities;

namespace SistemaGestionUI.ClientServices
{
    public class UsuarioBusiness
    {
        private readonly HttpClient _httpClient;

        public UsuarioBusiness(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>?> GetUsuarios()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("");
        }

        public async Task<Usuario?> GetOneUsuario(int id)
        {
            return await _httpClient.GetFromJsonAsync<Usuario>($"{id}");
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            await _httpClient.PostAsJsonAsync("", usuario);
        }

        public async Task UpdateUsuario(int id, Usuario usuario)
        {
            await _httpClient.PutAsJsonAsync($"{id}", usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _httpClient.DeleteAsync($"{id}");
        }

        public async Task<List<Usuario>?> GetUsuariosBy(string filtro)
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>(
                QueryHelpers.AddQueryString("", new Dictionary<string, string>() { { "filtro", filtro } }));
        }

        public async Task<Usuario?> IniciarSesion(string email, string password)
        {
            var loginRequest = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("login", loginRequest);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }

        // Método para obtener el nombre de un usuario por su ID
        public async Task<string?> GetNombreUsuario(int id)
        {
            return await _httpClient.GetStringAsync($"{id}/nombre");
        }
    }
}
