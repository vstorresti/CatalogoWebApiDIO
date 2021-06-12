using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.ViewModel;

namespace ApiCatalogoJogos.Services.Interfaces
{
    public interface IJogoService
    {
         Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
         Task<JogoViewModel> Obter(Guid id);
         Task<JogoViewModel> Inserir(JogoInputModel jogo);
         Task Atualizar(Guid id, JogoInputModel jogo);
         Task Atualizar(Guid id, double preco);
         Task Remover(Guid id);
    }
}