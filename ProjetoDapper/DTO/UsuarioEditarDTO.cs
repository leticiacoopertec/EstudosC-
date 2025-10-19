namespace CrudDapperVideo.DTO
{
    public class UsuarioEditarDTO
    {
        public int id { get; set; }
        public string nomeCompleto { get; set; }
        public string email { get; set; }
        public string cargo { get; set; }
        public double salario { get; set; }
        public string cpf { get; set; }
        public bool situacao { get; set; } // 1 - Ativo | 0 - Inativo
    }
}
