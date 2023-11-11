using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;

namespace ProjetoCadastroDeFamilias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;

        public FamiliaController(IFamiliaRepositorio familiaRepositorio)
        {
            _familiaRepositorio = familiaRepositorio;
        }

        [HttpGet]
        [Route("BuscarTodas")]
        public async Task<ActionResult<List<FamiliaModel>>> BuscarTodasFamilias()
        {
            List<FamiliaModel> familias = await _familiaRepositorio.ListarFamilias();
            return Ok(familias);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<List<FamiliaModel>>> BuscarFamiliaPorId(int id)
        {
            FamiliaModel familia = await _familiaRepositorio.ListarFamiliasPorId(id);
            return Ok(familia);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<FamiliaModel>> CadastrarFamilia([FromBody] FamiliaModel familiaModel)
        {
            FamiliaModel familia = await _familiaRepositorio.Adicionar(familiaModel);

            return Ok(familia);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<FamiliaModel>> Atualizar([FromBody] FamiliaModel familiaModel, int id)
        {
            familiaModel.Id = id;

            FamiliaModel familia = await _familiaRepositorio.Atualizar(familiaModel, id);

            return Ok(familia);
        }

        [HttpDelete]
        [Route("Apagar")]
        public async Task<ActionResult<FamiliaModel>> Apagar(int id)
        {
            bool familiaApagada = await _familiaRepositorio.Apagar(id);
            return Ok(familiaApagada);
        }
    }
}
