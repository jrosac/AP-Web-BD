namespace Marketplace.API.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string conta_bancaria { get; set; }
        public string nome { get; set; }
        public Endereco endereco { get; set; } = new Endereco();
        public int[] telefone { get; set; }
    }
    public class Endereco
    {
        public int CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

}
