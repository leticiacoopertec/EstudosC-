using CrudDapperVideo.DTO;
using CrudDapperVideo.Models;

namespace CrudDapperVideo.Services {
    public interface IUsuarioInterface {
        string nome();

        //Metodo assincrono
        Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios();
    }
}
 