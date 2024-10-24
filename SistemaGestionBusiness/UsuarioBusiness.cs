using SistemaGestionData.DataAccess;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBusiness;

public class UsuarioBusiness
{
    private UsuariosDataAccess _usuariosDataAccess;

    public UsuarioBusiness(UsuariosDataAccess usuariosDataAccess)
    {
        _usuariosDataAccess = usuariosDataAccess;
    }

    public List<Usuario> GetUsuarios()
    {
        return _usuariosDataAccess.GetUsuarios();
    }

    public Usuario? GetOneUsuario(int id)
    {
        return _usuariosDataAccess.GetOneUsuario(id);
    }

    public Usuario InsertUsuario(Usuario usuario)
    {
       return _usuariosDataAccess.InsertUsuario(usuario);
    }

    public void UpdateUsuario(int id, Usuario usuario)
    {
        _usuariosDataAccess.UpdateUsuario(id, usuario);
    }

    public void DeleteUsuario(int id)
    {
        _usuariosDataAccess.DeleteUsuario(id);
    }

    public List<Usuario> GetUsuariosBy(string filtro)
    {
        return _usuariosDataAccess.GetUsuariosBy(filtro);
    }

    // Método para iniciar sesión
    public Usuario? IniciarSesion(string email, string password)
    {
        return _usuariosDataAccess.IniciarSesion(email, password);
    }

    // Método para obtener el nombre de un usuario por su ID
    public string? GetNombreUsuario(int id)
    {
        return _usuariosDataAccess.GetNombreUsuario(id);
    }
}
