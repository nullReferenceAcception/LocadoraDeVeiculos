using FluentValidation;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
        Servico GetServico<Entidade, Servico, Tvalidador>()
            where Servico : ServicoBase<Entidade, Tvalidador>
            where Entidade : EntidadeBase<Entidade>
            where Tvalidador : AbstractValidator<Entidade>;
    }
}
