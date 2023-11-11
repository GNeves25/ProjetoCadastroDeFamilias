using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Service.Interfaces;

namespace ProjetoCadastroDeFamilias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPorId(int id)
        {
            return await _service.BuscarPorId(id);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel PessoaModel)
        {
            return await _service.Cadastrar(PessoaModel);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel PessoaModel, int id)
        {
            return await _service.Atualizar(PessoaModel, id);
        }

        [HttpDelete]
        [Route("Apagar")]
        public async Task<bool> Apagar(int id)
        {
            var retorno = _service.Apagar(id);
            return await retorno;
        }

        [HttpGet]
        [Route("VerificarLocalizacao")]
        public async Task<ActionResult<LocalizacaoModel>> VerificarLocalizacao()
        {
            return await _service.VerificarLocalizacao();
        }

    }
}
