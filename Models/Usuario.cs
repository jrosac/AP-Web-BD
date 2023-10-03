namespace Marketplace.API.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string conta_bancaria { get; set; }
        public string nome { get; set; }
        public endereco_type endereco { get; set; } = new endereco_type();
        public int[] telefone { get; set; }
    }
    public class endereco_type
    {
        public int cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }

}
