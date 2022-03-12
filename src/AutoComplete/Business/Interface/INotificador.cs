using Autocomplete.Business.Notificacoes;
using System.Collections.Generic;
namespace Autocomplete.Business.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
