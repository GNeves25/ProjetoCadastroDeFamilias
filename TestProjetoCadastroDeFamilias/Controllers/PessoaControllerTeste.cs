using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoCadastroDeFamilias.Controllers;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Service.Interfaces;

namespace ProjetoProjetoCadastroDeFamilias.Controllers
{
    public class PessoaControllerTeste
    {
        [Fact]
        public async Task TestaPessoaBuscarTodosAsync()
        {
            // Arrange
            var mockPessoaService = new Mock<IPessoaService>();
            var listaDePessoas = new List<PessoaModel>
            {
             new PessoaModel { Id = 1,Nome = "Teste", Idade = 15, DataNascimento = new DateTime(1993, 10, 25), IdFamilia = 1 },
             new PessoaModel { Id = 2, Nome = "Maria", Idade = 25, DataNascimento = new DateTime(1993, 10, 25), IdFamilia = 1 }
            };

            mockPessoaService.Setup(service => service.BuscarTodos())
                .ReturnsAsync(new ActionResult<List<PessoaModel>>(listaDePessoas));

            var controller = new PessoaController(mockPessoaService.Object);

            // Act
            var result = await controller.BuscarTodos();

            // Assert
            var okResult = result.Should().BeOfType<ActionResult<List<PessoaModel>>>().Subject;
            var actionResultValue = okResult.Value;

            actionResultValue.Should().HaveCount(2);
            actionResultValue.Should().ContainSingle(p => p.Nome == "Teste");
            actionResultValue.Should().ContainSingle(p => p.Nome == "Maria");

        }

        [Fact]
        public async Task TestaPessoaBuscarPorIdAsync()
        {
            // Arrange
            var mockPessoaService = new Mock<IPessoaService>();
            var pessoa =
             new PessoaModel { Id = 1, Nome = "Teste", Idade = 15, DataNascimento = new DateTime(1993, 10, 25), IdFamilia = 1 };

            mockPessoaService.Setup(service => service.BuscarPorId(pessoa.Id))
                .ReturnsAsync(pessoa);

            var controller = new PessoaController(mockPessoaService.Object);

            // Act
            var result = await controller.BuscarPorId(pessoa.Id);

            // Assert
            var createdResult = result.Should().BeOfType<ActionResult<PessoaModel>>().Subject;
            var actionResult = createdResult.Value;
            actionResult.Should().BeEquivalentTo(pessoa);

        }

        [Fact]
        public async Task TestaPessoaCreateAsync()
        {
            // Arrange
            var mockPessoaService = new Mock<IPessoaService>();
            var pessoaCadastro = new PessoaModel { Id = 1, Nome = "Teste", Idade = 15, DataNascimento = new DateTime(1993, 10, 25), IdFamilia = 1 };
            var listaDePessoas = new List<PessoaModel>
            {
             new PessoaModel { Id = 1,Nome = "Teste", Idade = 15, DataNascimento = new DateTime(1993, 10, 25), IdFamilia = 1 },
             new PessoaModel { Id = 2, Nome = "Maria", Idade = 25, DataNascimento = new DateTime(1993, 10, 25), IdFamilia = 1 }
            };

            mockPessoaService.Setup(service => service.Cadastrar(pessoaCadastro))
            .ReturnsAsync((PessoaModel pessoa) =>
            {
                return new CreatedAtActionResult(
                    "Get",
                    "Pessoa",
                    new { id = 1 },
                    pessoa
                );
            });

            var controller = new PessoaController(mockPessoaService.Object);

            // Act
            var result = await controller.Cadastrar(pessoaCadastro);

            // Assert
            var createdResult = result.Should().BeOfType<ActionResult<PessoaModel>>().Subject;
            var actionResult = createdResult.Result.Should().BeOfType<CreatedAtActionResult>().Subject;

            actionResult.ActionName.Should().Be("Get");
            actionResult.ControllerName.Should().Be("Pessoa");
            actionResult.RouteValues["id"].Should().Be(1);
            actionResult.Value.Should().BeEquivalentTo(pessoaCadastro);
        }
    }
}
