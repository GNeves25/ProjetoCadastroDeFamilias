using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamilias.Service.Interfaces
{
    public interface IFamiliaService
    {
        Task<ActionResult<List<FamiliaModel>>> BuscarTodasFamilias();
        public Task<ActionResult<FamiliaModel>> BuscarFamiliaPorId(int id);
        public Task<ActionResult<FamiliaModel>> CadastrarFamilia([FromBody] FamiliaModel familiaModel);
        public Task<ActionResult<FamiliaModel>> Atualizar([FromBody] FamiliaModel familiaModel, int id);
        public Task<bool> Apagar(int id);
    }
}
