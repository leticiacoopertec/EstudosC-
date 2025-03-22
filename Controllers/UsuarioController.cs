using CrudDapperVideo.DTO;
using CrudDapperVideo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapperVideo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase {

        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface) 
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            try
            {
                var usuario = await _usuarioInterface.BuscarUsuarios();
                if (usuario.Status == false)
                {
                    return NotFound(usuario);
                }
                return Ok(usuario);
            }catch(Exception e) { throw e; }
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> BuscarUsusarioPorID(int idUsuario)
        {
            try
            {
                var usuario = await _usuarioInterface.BuscarUsusarioPorID(idUsuario);
                if (usuario.Status == false)
                {
                    return NotFound(usuario);
                }
                return Ok(usuario);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarDTO usuarioCriarDTO)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(usuarioCriarDTO);

            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }
            return Ok(usuarios);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioEditarDTO usuarioEditarDTO)
        {
            var usuarios = await _usuarioInterface.EditarUsuario(usuarioEditarDTO);

            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }
            return Ok(usuarios);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario(int idUsuario)
        {
            var usuarios = await _usuarioInterface.RemoverUsuario(idUsuario);

            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }
            return Ok(usuarios);
        }

    }
}
