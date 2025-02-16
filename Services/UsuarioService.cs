using CrudDapperVideo.DTO;
using CrudDapperVideo.Models;
using System.Globalization;

namespace CrudDapperVideo.Services {
    public class UsuarioService : IUsuarioInterface
    {
        //Injeção de dependencia
        //Preciso do Iconfiguration para acessar o arquivo appsettings.json pois
        //eh nele que irei guardar a string dfe conexão com o banco
        private readonly IConfiguration _configuration;
        //Injeção de dependencia
        public UsuarioService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios()
        {
            throw new NotImplementedException();
        }

        public string nome() {
            return "";
        }



    }
}
