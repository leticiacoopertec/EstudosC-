namespace CrudDapperVideo.DTO
{
    public class UsuarioListarDTO
    {
        public int id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
       // public string Senha { get; set; }
        public double Salario { get; set; }
        // public string Cpf { get; set; }
        public bool Situação { get; set; } // 1 - Ativo | 0 - Inativo
    }
}
