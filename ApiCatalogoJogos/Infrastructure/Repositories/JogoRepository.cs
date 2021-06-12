using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.Infrastructure.Interfaces;

namespace ApiCatalogoJogos.Infrastructure.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("6fd18e5a-bc23-404a-a5ae-41bf2c449e75"), new Jogo {Id = Guid.Parse("6fd18e5a-bc23-404a-a5ae-41bf2c449e75"), Nome = "GTA", Produtora = "Rockstar", Preco = 200}},
            {Guid.Parse("785d02f6-3ed4-4ff0-9f4b-768aefd94937"), new Jogo {Id = Guid.Parse("785d02f6-3ed4-4ff0-9f4b-768aefd94937"), Nome = "COD", Produtora = "Activision", Preco = 400}},
            {Guid.Parse("dbced64d-c08f-45a2-9540-10da169e92a4"), new Jogo {Id = Guid.Parse("dbced64d-c08f-45a2-9540-10da169e92a4"), Nome = "Doom", Produtora = "Bethesda", Preco = 100}},
            {Guid.Parse("ad980d55-b605-4c86-bf93-ac62b3fcdc7d"), new Jogo {Id = Guid.Parse("ad980d55-b605-4c86-bf93-ac62b3fcdc7d"), Nome = "Fifa", Produtora = "EA", Preco = 350}}
        };
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Nao Implementado
        }

        public Task<Jogo> Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.FromResult(jogos[jogo.Id]);
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina -1)* quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
    }
}