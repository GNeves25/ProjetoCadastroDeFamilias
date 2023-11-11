namespace ProjetoCadastroDeFamilias.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdFamilia { get; set; }
    }
}
