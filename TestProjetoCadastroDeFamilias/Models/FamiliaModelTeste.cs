using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamiliasTeste.Models
{
    public class FamiliaModelTeste
    {
        [Fact]
        public void TesteCriarFamilia()
        {
            FamiliaModel famila = CriarFamilia();

            Assert.Equal(1, famila.Id);
            Assert.Equal(1, famila.QuantidadeDePessoas);
            Assert.Equal("Teste 3", famila.NomeFamilia);

        }

        private static FamiliaModel CriarFamilia()
        {
            return new FamiliaModel
            {
                Id = 1,
                QuantidadeDePessoas = 1,
                NomeFamilia = "Teste 3"
            };
        }
    }
}
