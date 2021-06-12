using System;

namespace ApiCatalogoJogos.Entities.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException()
            : base("Este jogo já está cadastrado")
            { }
    }
}