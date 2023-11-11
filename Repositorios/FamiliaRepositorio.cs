using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeFamilias.Data;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;

namespace ProjetoCadastroDeFamilias.Repositorios
{
    public class FamiliaRepositorio : IFamiliaRepositorio
    {
        private readonly SistemaDeCadastroDBContext _dbContext;
        public FamiliaRepositorio(SistemaDeCadastroDBContext sistemaDeCadastroDBContext)
        {
            _dbContext = sistemaDeCadastroDBContext;
        }

        public async Task<List<FamiliaModel>> ListarFamilias()
        {
            return await _dbContext.Familias.ToListAsync();
        }

        public async Task<FamiliaModel> ListarFamiliasPorId(int id)
        {
            var listaFamiliaPorId = await _dbContext.Familias.FirstOrDefaultAsync(x => x.Id == id);

            return listaFamiliaPorId;
        }
        public async Task<FamiliaModel> Adicionar(FamiliaModel familia)
        {
            await _dbContext.Familias.AddAsync(familia);
            await _dbContext.SaveChangesAsync();

            return familia;
        }

        public async Task<FamiliaModel> Atualizar(FamiliaModel familia, int id)
        {
            var familiaAtualiza = await ListarFamiliasPorId(id);

            if (familiaAtualiza == null)
            {
                throw new Exception($"Familia {id} não encontrada.");
            }

            familiaAtualiza.NomeFamilia = familia.NomeFamilia;
            familiaAtualiza.QuantidadeDePessoas = familia.QuantidadeDePessoas;

            _dbContext.Familias.Update(familiaAtualiza);
            await _dbContext.SaveChangesAsync();

            return familiaAtualiza;
        }

        public async Task<bool> Apagar(int id)
        {
            var familiaAtualiza = await ListarFamiliasPorId(id);

            if (familiaAtualiza == null)
            {
                throw new Exception($"Familia {id} não encontrada.");
            }

            _dbContext.Familias.Remove(familiaAtualiza);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
