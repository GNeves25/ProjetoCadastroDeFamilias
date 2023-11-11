using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeFamilias.Data;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;

namespace ProjetoCadastroDeFamilias.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly SistemaDeCadastroDBContext _dbContext;
        private readonly IFamiliaRepositorio _familiaRepositorio;

        public PessoaRepositorio(SistemaDeCadastroDBContext sistemaDeCadastroDBContext, IFamiliaRepositorio familiaRepositorio)
        {
            _dbContext = sistemaDeCadastroDBContext;
            _familiaRepositorio = familiaRepositorio;
        }

        public async Task<List<PessoaModel>> BuscarTodos()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }

        public async Task<PessoaModel> BuscarPorId(int id)
        {
            var pessoa = await _dbContext.Pessoa.FirstOrDefaultAsync(p => p.Id == id);
            return pessoa;
        }

        public async Task<PessoaModel> Cadastrar(PessoaModel pessoa)
        {
            var familia = await _familiaRepositorio.ListarFamiliasPorId(pessoa.IdFamilia);

            if (familia == null)
            {
                throw new Exception($"Familia {pessoa.IdFamilia} não encontrada");
            }

            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<PessoaModel> Atualizar(PessoaModel pessoa, int id)
        {
            var pessoaAtualiza = await BuscarPorId(id);

            if (pessoaAtualiza == null)
            {
                throw new Exception($"Pessoa {id} não encontrada");
            }

            ConvertePessoa(pessoa, pessoaAtualiza);

            _dbContext.Pessoa.Update(pessoaAtualiza);
            await _dbContext.SaveChangesAsync();

            return pessoaAtualiza;
        }

        public async Task<bool> Apagar(int id)
        {
            PessoaModel pessoaAtualiza = await BuscarPorId(id);

            if (pessoaAtualiza == null)
            {
                throw new Exception($"Pessoa {id} não encontrada");
            }

            _dbContext.Pessoa.Remove(pessoaAtualiza);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private static void ConvertePessoa(PessoaModel pessoa, PessoaModel pessoaAtualiza)
        {
            pessoaAtualiza.Nome = pessoa.Nome;
            pessoaAtualiza.Idade = pessoa.Idade;
            pessoaAtualiza.DataNascimento = pessoa.DataNascimento;
        }

    }
}
