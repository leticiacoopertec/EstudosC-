namespace CrudDapperVideo.Models {
    public class ResponseModel<T> {
        public T? Dados {  get; set; } // Qualquer tipo, T, de Dado usando o genérico
        public string Mesagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
 