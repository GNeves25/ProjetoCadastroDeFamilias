using ProjetoCadastroDeFamilias.Models;

namespace TestProjetoCadastroDeFamilias.Models
{
    public class PessoaModelTeste
    {
        [Fact]
        public void TesteCriarPessoa()
        {
            PessoaModel pessoa = CriarPessoa();

            Assert.Equal(1, pessoa.Id);
            Assert.Equal("Teste", pessoa.Nome);
            Assert.Equal(15, pessoa.Idade);
            Assert.Equal(new DateTime(1993, 10, 25), pessoa.DataNascimento);

        }

        private static PessoaModel CriarPessoa()
        {
            return new PessoaModel
            {
                Id = 1,
                Nome = "Teste",
                Idade = 15,
                DataNascimento = new DateTime(1993, 10, 25),
                IdFamilia = 1
            };
        }
    }
}
