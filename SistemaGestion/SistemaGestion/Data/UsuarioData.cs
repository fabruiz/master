using System.Collections.Generic;
using System.Linq;
using SistemaGestion;
using SistemaGestion.Data;
using SistemaGestion.Model;

public static class UsuarioData
{
    public static Usuario ObtenerUsuario(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Usuarios.Find(id);
        }
    }

    public static List<Usuario> ListarUsuarios()
    {
        using (var context = new AppDbContext())
        {
            return context.Usuarios.ToList();
        }
    }

    public static void CrearUsuario(Usuario Usuario)
    {
        using (var context = new AppDbContext())
        {
            if (!context.Usuarios.Any(u => u.NombreUsuario == Usuario.NombreUsuario))
            {
                context.Usuarios.Add(Usuario);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("El nombre de usuario ya existe.");
            }
        }
    }

    public static void ModificarUsuario(Usuario Usuario)
    {
        using (var context = new AppDbContext())
        {
            context.Usuarios.Update(Usuario);
            context.SaveChanges();
        }
    }

    public static void EliminarUsuario(int id)
    {
        using (var context = new AppDbContext())
        {
            var Usuario = context.Usuarios.Find(id);
            if (Usuario != null)
            {
                context.Usuarios.Remove(Usuario);
                context.SaveChanges();
            }
        }
    }
}
