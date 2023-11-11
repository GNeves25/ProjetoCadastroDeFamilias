using IpPublicKnowledge;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoCadastroDeFamilias.Models;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;
using ProjetoCadastroDeFamilias.Service.Interfaces;

namespace ProjetoCadastroDeFamilias.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IConfiguration _configuration;

        public PessoaService(IPessoaRepositorio pessoaRepositorio, IConfiguration configuration)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _configuration = configuration;
        }

        public async Task<ActionResult<List<PessoaModel>>> BuscarTodos()
        {
            return await _pessoaRepositorio.BuscarTodos();
        }

        public async Task<ActionResult<PessoaModel>> BuscarPorId(int id)
        {
            return await _pessoaRepositorio.BuscarPorId(id);
        }

        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel pessoaModel)
        {
            return await _pessoaRepositorio.Cadastrar(pessoaModel);
        }

        public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel PessoaModel, int id)
        {
            PessoaModel.Id = id;

            return await _pessoaRepositorio.Atualizar(PessoaModel, id);
        }

        public async Task<bool> Apagar(int id)
        {
            return await _pessoaRepositorio.Apagar(id);
        }

        public async Task<ActionResult<LocalizacaoModel>> VerificarLocalizacao()
        {
            return await ObterLocalizacao();
        }

        private async Task<LocalizacaoModel> ObterLocalizacao()
        {
            var httpClient = new HttpClient();
            var ip = IPK.GetMyPublicIp();
            var chave = _configuration.GetSection("ip2location:chave").Value;
            var caminho = _configuration.GetSection("ip2location").GetSection("caminho").Value;
            var response = await httpClient.GetStringAsync($"{caminho}?key={chave}&ip={ip}&format=json");

            LocalizacaoModel localizacao = JsonConvert.DeserializeObject<LocalizacaoModel>(response);
            return localizacao;
        }
    }
}
