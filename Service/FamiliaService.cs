using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;
using ProjetoCadastroDeFamilias.Service.Interfaces;

namespace ProjetoCadastroDeFamilias.Service
{
    public class FamiliaService : IFamiliaService
    {
        private readonly IFamiliaRepositorio _familiaRepositorio;

        public FamiliaService(IFamiliaRepositorio familiaRepositorio)
        {
            _familiaRepositorio = familiaRepositorio;
        }

        public async Task<ActionResult<List<FamiliaModel>>> BuscarTodasFamilias()
        {
            return await _familiaRepositorio.ListarFamilias();
        }

        public async Task<ActionResult<FamiliaModel>> BuscarFamiliaPorId(int id)
        {
            return await _familiaRepositorio.ListarFamiliasPorId(id);
        }

        public async Task<ActionResult<FamiliaModel>> CadastrarFamilia([FromBody] FamiliaModel familiaModel)
        {
            return await _familiaRepositorio.Adicionar(familiaModel);
        }

        public async Task<ActionResult<FamiliaModel>> Atualizar([FromBody] FamiliaModel familiaModel, int id)
        {
            return await _familiaRepositorio.Atualizar(familiaModel, id);
        }

        public Task<bool> Apagar(int id)
        {
            return _familiaRepositorio.Apagar(id);
        }
    }
}
