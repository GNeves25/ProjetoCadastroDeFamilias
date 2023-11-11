using Microsoft.Extensions.Configuration;
using Moq;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;
using ProjetoCadastroDeFamilias.Service;

namespace ProjetoCadastroDeFamiliasTeste.Repositorio
{
    public class PessoaRepositorioTeste
    {
        private readonly Mock<IPessoaRepositorio> _repositorioPessoaMock;
        private readonly PessoaService _pessoaService;
        private readonly Mock<IConfiguration> _configurationMock;

        public PessoaRepositorioTeste()
        {
            _repositorioPessoaMock = new Mock<IPessoaRepositorio>();
            _configurationMock = new Mock<IConfiguration>();
            _pessoaService = new PessoaService(_repositorioPessoaMock.Object, _configurationMock.Object);
        }

        [Fact]
        public async Task TestarListarTodosAsync()
        {
            await _pessoaService.BuscarTodos();

            _repositorioPessoaMock.Verify(r => r.BuscarTodos(), Times.Once);
        }

        [Fact]
        public async Task TestarListarPorIdAsync()
        {
            var pessoaTeste = CriarPessoa();
            await _pessoaService.BuscarPorId(pessoaTeste.Id);

            _repositorioPessoaMock.Verify(r => r.BuscarPorId(pessoaTeste.Id), Times.Once);
        }

        [Fact]
        public async Task TestarCadastroAsync()
        {
            var familiapessoa = CriarFamilia();
            var pessoaTeste = CriarPessoa();
            await _pessoaService.Cadastrar(pessoaTeste);

            _repositorioPessoaMock.Verify(r => r.Cadastrar(pessoaTeste), Times.Once);
        }

        [Fact]
        public async Task TestarAlteracaoAsync()
        {
            var pessoaTeste = CriarPessoa();
            await _pessoaService.Atualizar(pessoaTeste, pessoaTeste.Id);

            _repositorioPessoaMock.Verify(r => r.Atualizar(pessoaTeste, pessoaTeste.Id), Times.Once);
        }

        [Fact]
        public async Task TestarExclusaoAsync()
        {
            var pessoaTeste = CriarPessoa();
            await _pessoaService.Apagar(pessoaTeste.Id);

            _repositorioPessoaMock.Verify(r => r.Apagar(pessoaTeste.Id), Times.Once);
        }


        private static PessoaModel CriarPessoa()
        {
            return new PessoaModel { Id = 1, Nome = "Teste", DataNascimento = new DateTime(1993, 10, 25), Idade = 29, IdFamilia = 1 };
        }

        private static FamiliaModel CriarFamilia()
        {
            return new FamiliaModel { Id = 1, QuantidadeDePessoas = 1, NomeFamilia = "Teste" };
        }
    }
}
