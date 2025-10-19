using CrudDapperVideo.DTO;
using CrudDapperVideo.Models;

namespace CrudDapperVideo.Services {
    public interface IUsuarioInterface {
        string nome();

        //Metodo assincrono
        Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios();
        Task<ResponseModel<Usuario>> BuscarUsusarioPorID(int idUsuario);
        Task<ResponseModel<List<UsuarioListarDTO>>> CriarUsuario(UsuarioCriarDTO usuarioCriarDTO);
        Task<ResponseModel<List<UsuarioListarDTO>>> EditarUsuario(UsuarioEditarDTO usuarioEditarDTO);
        Task<ResponseModel<List<UsuarioListarDTO>>> RemoverUsuario(int idUsuario);
    }
}
 