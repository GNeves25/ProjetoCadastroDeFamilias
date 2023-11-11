using Moq;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;
using ProjetoCadastroDeFamilias.Service;

namespace TestProjetoCadastroDeFamilias.Repositorios
{
    public class FamiliaRepositorioTeste
    {
        private readonly Mock<IFamiliaRepositorio> _repositorioFamiliaMock;
        private readonly FamiliaService _familiaService;

        public FamiliaRepositorioTeste()
        {
            _repositorioFamiliaMock = new Mock<IFamiliaRepositorio>();
            _familiaService = new FamiliaService(_repositorioFamiliaMock.Object);
        }

        [Fact]
        public async Task TestarListarTodosAsync()
        {
            await _familiaService.BuscarTodasFamilias();

            _repositorioFamiliaMock.Verify(r => r.ListarFamilias(), Times.Once);
        }

        [Fact]
        public async Task TestarListarPorIdAsync()
        {
            var familiaModelo = GerarFamilia();
            await _familiaService.BuscarFamiliaPorId(familiaModelo.Id);

            _repositorioFamiliaMock.Verify(r => r.ListarFamiliasPorId(familiaModelo.Id), Times.Once);
        }

        [Fact]
        public async Task TestarCadastroAsync()
        {
            var familiaModelo = GerarFamilia();
            await _familiaService.CadastrarFamilia(familiaModelo);

            _repositorioFamiliaMock.Verify(r => r.Adicionar(familiaModelo), Times.Once);
        }

        [Fact]
        public async Task TestarAlteracaoAsync()
        {
            var familiaModelo = GerarFamilia();
            await _familiaService.Atualizar(familiaModelo, familiaModelo.Id);

            _repositorioFamiliaMock.Verify(r => r.Atualizar(familiaModelo, familiaModelo.Id), Times.Once);
        }

        [Fact]
        public async Task TestarExclusaoAsync()
        {
            var familiaModelo = GerarFamilia();
            await _familiaService.Apagar(familiaModelo.Id);

            _repositorioFamiliaMock.Verify(r => r.Apagar(familiaModelo.Id), Times.Once);
        }

        private static FamiliaModel GerarFamilia()
        {
            return new FamiliaModel { Id = 1, QuantidadeDePessoas = 1, NomeFamilia = "Teste" };
        }
    }
}
