using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamilias.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<ActionResult<List<PessoaModel>>> BuscarTodos();
        public Task<ActionResult<PessoaModel>> BuscarPorId(int id);
        public Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel PessoaModel);
        public Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel PessoaModel, int id);
        public Task<bool> Apagar(int id);
        public Task<ActionResult<LocalizacaoModel>> VerificarLocalizacao();
    }
}
