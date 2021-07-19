using MHP.Books.Business.Notificacoes;
using System.Collections.Generic;

namespace MHP.Books.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}