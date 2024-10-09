using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Data;
using SistemaGestion.Model;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Createusuario([FromBody] Usuario usuario)
        {
            try
            {
                UsuarioData.CrearUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Getusuario(int id)
        {
            var usuario = UsuarioData.ObtenerUsuario(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public IActionResult Listusuarios()
        {
            var usuarios = UsuarioData.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpPut]
        public IActionResult Updateusuario([FromBody] Usuario usuario)
        {
            try
            {
                UsuarioData.ModificarUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteusuario(int id)
        {
            try
            {
                UsuarioData.EliminarUsuario(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
