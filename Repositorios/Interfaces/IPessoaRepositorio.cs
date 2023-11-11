using ProjetoCadastroDeFamilias.Models;

namespace ProjetoCadastroDeFamilias.Repositorios.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<List<PessoaModel>> BuscarTodos();
        Task<PessoaModel> BuscarPorId(int id);
        Task<PessoaModel> Cadastrar(PessoaModel pessoa);
        Task<PessoaModel> Atualizar(PessoaModel pessoa, int id);
        Task<bool> Apagar(int id);
    }
}
