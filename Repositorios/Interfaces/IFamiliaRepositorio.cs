using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamilias.Repositorios.Interfaces
{
    public interface IFamiliaRepositorio
    {
        Task<List<FamiliaModel>> ListarFamilias();
        Task<FamiliaModel> ListarFamiliasPorId(int id);
        Task<FamiliaModel> Adicionar(FamiliaModel familia);
        Task<FamiliaModel> Atualizar(FamiliaModel familia, int id);
        Task<bool> Apagar(int id);
    }
}
