using AutoMapper;
using CrudDapperVideo.DTO;
using CrudDapperVideo.Models;
using Dapper;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CrudDapperVideo.Services {
    public class UsuarioService : IUsuarioInterface
    {
        //Injeção de dependencia
        //Preciso do Iconfiguration para acessar o arquivo appsettings.json pois
        //eh nele que irei guardar a string dfe conexão com o banco
        private readonly string _connectionString;

        private readonly IMapper _mapper;
        //Injeção de dependencia
        //para poder usar o mapper nessa classe tem que importar o mapper por injeção de dependencia
        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _mapper = mapper;
        }

        
        public async Task<ResponseModel<List<UsuarioListarDTO>>> BuscarUsuarios()
        {

            ResponseModel<List<UsuarioListarDTO>> response = new();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre a conexão
                var query = "SELECT * FROM Usuarios";
                var usuariosBanco = await connection.QueryAsync<Usuario>(query);

                if (usuariosBanco.Count() == 0)
                {
                    response.Mesagem = "Nenhum usuario localizado.";
                    response.Status = false;
                    return response;
                }

                //transformar de usuario para usuariodto com mapper
                var usuariosMapeados = _mapper.Map<List<UsuarioListarDTO>>(usuariosBanco);

                response.Dados = usuariosMapeados;
                response.Mesagem = "Usuarios localizados com sucessos.";
            }
            return response;
        }

        public async Task<ResponseModel<UsuarioListarDTO>> BuscarUsusarioPorID(int idUsuario)
        {
            ResponseModel<UsuarioListarDTO> response = new();

            using (var connection = new NpgsqlConnection(_connectionString)) 
            {
                string sql = $"Select * from Usuarios where id = {idUsuario}";
                var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>(sql);

                if(usuarioBanco == null)
                {
                    response.Mesagem = "Usuario não encontrado!";
                    response.Status = false;
                    return  response;
                }

                //TRansformar ususario em usuarioListaDTO
                var usuariomapeado = _mapper.Map<UsuarioListarDTO>(usuarioBanco);
                response.Mesagem = "Usuario encontrado!";
                response.Dados = usuariomapeado;
            }
            
            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDTO>>> CriarUsuario(UsuarioCriarDTO usuarioCriarDTO)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $@"INSERT INTO Usuarios(
	                             nomecompleto, email, cargo, cpf, salario, situacao, senha)
	                            VALUES (@nomeCompleto,
                                        @email, 
                                        @cargo, 
                                        @cpf, 
                                        @salario, 
                                        @situacao,
                                        @senha);";  
                var usuarioInsert = await connection.ExecuteAsync(sql, usuarioCriarDTO);

                if(usuarioInsert == 0)
                {
                    response.Mesagem = "Erro ao criar usuario";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                response.Dados = _mapper.Map<List<UsuarioListarDTO>>(usuarios); 
                response.Mesagem = "suario inserido com sucesso!";

            }
            return response;
        }

        private static async Task<IEnumerable<Usuario>> ListarUsuarios(NpgsqlConnection conection)
        {
            return await conection.QueryAsync<Usuario>("select * from usuarios");
        }

        public string nome() {
            return "";
        }

        public async Task<ResponseModel<List<UsuarioListarDTO>>> EditarUsuario(UsuarioEditarDTO usuarioEditarDTO)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $@"Update Usuarios
                                SET nomecompleto= @nomecompleto, 
                                    email=@email, 
                                    cargo=@cargo, 
                                    cpf=@cpf, 
                                    salario=@salario,  
                                    situacao= @situacao
                                where id = {usuarioEditarDTO.id}";
                var usuario = await connection.ExecuteAsync(sql, usuarioEditarDTO);

                if (usuario == 0)
                {
                    response.Mesagem = "Erro ao atualizar o susuario";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                response.Dados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
                response.Mesagem = "Usuario atualizado com sucesso!";
            }

            return response; 
        }

        public async Task<ResponseModel<List<UsuarioListarDTO>>> RemoverUsuario(int idUsuario)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $@"delete from Usuarios where id = {idUsuario}";
                var usuario = await connection.ExecuteAsync(sql);
                if (usuario == 0)
                {
                    response.Mesagem = "Erro ao deletar o usuario";
                    response.Status = false;
                }

                var usuarios = await ListarUsuarios(connection);

                response.Dados = _mapper.Map<List<UsuarioListarDTO>>(usuarios);
                response.Mesagem = "Ususario excluido com sucesso!";
            }
            return response;
        }
    }
}
